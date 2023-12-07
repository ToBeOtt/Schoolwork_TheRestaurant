using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Application.Orders.Interfaces;
using TheRestaurant.Contracts.Requests.Order;
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


        //public void SetOrderStatus(Order order, string status)
        //{
        //    var orderStatus = new OrderStatus { Status = status };
        //    order.OrderStatus = orderStatus;
        //}
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

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _orderRepository.GetByIdAsync(orderId);
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
            await _orderRepository.DeleteAsync(orderId);
        }
    }
}
