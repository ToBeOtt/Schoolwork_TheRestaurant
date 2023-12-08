using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Application.Orders.Interfaces;
using TheRestaurant.Contracts.Requests.Order;
using TheRestaurant.Contracts.Responses.Orders;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Application.Orders
{
    public class OrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(
            ILogger<OrderService> logger,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public async Task<ServiceResponse<int>> CreateOrderAsync(CreateOrderRequest request)
        {
            ServiceResponse<int> response = new();

            Order order = new();
            order.OrderDate = DateTime.Now;
            order.OrderStatus = await GetPendingStatusForOrder();
            var persistedOrder = await _orderRepository.CreateAsync(order);
            if (persistedOrder == null)
                return await response.ErrorResponse
                      (response, "Could not persist order", _logger);

            // loops through data and produces products and attach these to order-rows.
            foreach (var item in request.ProductAggregate)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                for (int i = 0; i < item.ProductCount; i++)
                {
                    OrderRow orderRow = new (product, order);
                    if (!await _orderRepository.CreateOrderRow(orderRow))
                        throw new DbUpdateException();
                }
            }
            response.Data = persistedOrder.Id;

            return await response.SuccessResponse(response, response.Data);
        }

        private async Task<OrderStatus> GetPendingStatusForOrder()
        {
            return await _orderRepository.GetPendingStatusId();
        }


        public async Task<List<Order>> GetOrderByOrderStatus(string orderStatus)
        {
            return await _orderRepository.GetOrdersByStatus(orderStatus);
        }
       

        public async Task<ServiceResponse<GetCustomerOrderResponse>> GetCustomerOrder(int orderId)

        {
            ServiceResponse<GetCustomerOrderResponse> response = new();

            var order =  await _orderRepository.GetByIdAsync(orderId);
            if(order == null)
                return await response.ErrorResponse
                      (response, "Order could not be fetched from database.", _logger);

            GetCustomerOrderResponse dto = new(
                OrderNr: order.Id,
                ProductName: order.OrderRows.Select(item => item.Product.Name).ToList(),
                Status: order.OrderStatus.Status,
                SumToPay: order.OrderRows.Sum(item => item.Product.Price)
                );

            response.Data = dto;
            return await response.SuccessResponse(response, response.Data);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                // felhantering
            }
            order.IsDeleted = true;
            await _orderRepository.DeleteAsync(order);
        }

        public async Task<ServiceResponse<List<ActiveOrdersResponse>>> GetListOfActiveOrders()
        {
            ServiceResponse<List<ActiveOrdersResponse>> response = new();

            var activeOrdersList = await _orderRepository.GetActiveOrders();
            if (activeOrdersList == null)
                return await response.ErrorResponse
                      (response, "Orders could not be fetched from database.", _logger);

            List<ActiveOrdersResponse> activeOrdersDtoList = new();

            foreach(var item in activeOrdersList)
            {
                var productAndQuantityList = item.OrderRows
                    .GroupBy(orderRow => orderRow.Product.Name)
                    .Select(group => new ProductAndQuantity
                    (
                        ProductName: group.Key,
                        Quantity: group.Count()
                    ))
                    .OrderBy(productAndQuantity => productAndQuantity.ProductName)
                    .ToList();

                ActiveOrdersResponse dto = new ActiveOrdersResponse(
                    OrderNr: item.Id,
                    DateTimeOfOrder: item.OrderDate,
                    ProductAndQuantity: productAndQuantityList
                );

                activeOrdersDtoList.Add(dto);
            }

            response.Data = activeOrdersDtoList;
            return await response.SuccessResponse(response, response.Data);
        }
    }
}
