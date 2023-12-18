using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheRestaurant.Application.Interfaces.IOrderStatus;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Application.Orders.Interfaces;
using TheRestaurant.Contracts.Requests.Order;
using TheRestaurant.Contracts.Responses.Orders;
using TheRestaurant.Contracts.Responses.ServiceResponse;
using TheRestaurant.Domain.Entities.Orders;
using TheRestaurant.Presentation.Shared.DTO.Dashboard;

namespace TheRestaurant.Application.Orders
{
    public class OrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderStatusRepository _orderStatusRepository;

        public OrderService(
            ILogger<OrderService> logger,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IOrderStatusRepository orderStatusRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderStatusRepository = orderStatusRepository;
        }
        public async Task<ServiceResponse<int>> CreateOrderAsync(CreateOrderRequest request)
        {
            ServiceResponse<int> response = new();

            Order order = new();
            order.OrderDate = DateTime.Now;
            order.OrderStatus = await _orderStatusRepository.GetAsync("Pending");
            order.OrderComment = request.Comment;
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

        public async Task<List<Order>> GetOrderByOrderStatus(string orderStatus)
        {
            return await _orderRepository.GetOrdersByStatus(orderStatus);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
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

        public async Task<ServiceResponse<bool>> UpdateOrderStatus(UpdateOrderStatusRequest request)
        {
            ServiceResponse<bool> response = new();

            var order = await _orderRepository.GetByIdAsync(request.Id);

            //Set new status
            var orderStatus = await _orderStatusRepository.GetAsync(request.OrderStatus);
            order.OrderStatus = orderStatus;



            var result = await _orderRepository.UpdateAsync(order);
            response.Data = result;
            if (result)
                return await response.SuccessResponse(response, response.Data);

            else
                return await response.ErrorResponse
                      (response, "Order could not be fetched from database.", _logger);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _orderRepository.UpdateAsync(order);
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


        public async Task<ServiceResponse<List<PendingOrdersResponse>>> GetListOfPendingOrders()
        {
            ServiceResponse<List<PendingOrdersResponse>> response = new();

            var pendingOrdersList = await _orderRepository.GetPendingOrders();
            if (pendingOrdersList == null)
                return await response.ErrorResponse
                      (response, "Orders could not be fetched from database.", _logger);

            List<PendingOrdersResponse> pendingOrdersDtoList = new();

            foreach (var item in pendingOrdersList)
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

                PendingOrdersResponse dto = new PendingOrdersResponse(
                    OrderNr: item.Id,
                    Comment: item.OrderComment,
                    DateTimeOfOrder: item.OrderDate,
                    ProductAndQuantity: productAndQuantityList,
                    EmployeeName: null
                );

                pendingOrdersDtoList.Add(dto);
            }

            response.Data = pendingOrdersDtoList;
            return await response.SuccessResponse(response, response.Data);
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
                    OrderComment: item.OrderComment,
                    DateTimeOfOrder: item.OrderDate,
                    ProductAndQuantity: productAndQuantityList,
                    EmployeeName: item.Employee.Alias
                );

                activeOrdersDtoList.Add(dto);
            }

            response.Data = activeOrdersDtoList;
            return await response.SuccessResponse(response, response.Data);
        }

        public async Task<ServiceResponse<List<FinishedOrderResponse>>> GetListOfFinishedOrders()
        {
            ServiceResponse<List<FinishedOrderResponse>> response = new();

            var finishedOrdersList = await _orderRepository.GetFinishedOrders();
            if (finishedOrdersList == null)
                return await response.ErrorResponse
                      (response, "Orders could not be fetched from database.", _logger);

            List<FinishedOrderResponse> finishedOrdersDtoList = new();

            foreach (var item in finishedOrdersList)
            {
                FinishedOrderResponse dto = new(
                    OrderNr: item.Id,
                    OrderComment: item.OrderComment,
                    DateTimeOfOrder: item.OrderDate,
                    EmployeeName: item.Employee.Alias
                );

                finishedOrdersDtoList.Add(dto);
            }

            response.Data = finishedOrdersDtoList;
            return await response.SuccessResponse(response, response.Data);
        }

        public async Task<ServiceResponse<GetReceiptResponse>> GetReceipt(GetReceiptRequest request)
        {
            ServiceResponse<GetReceiptResponse> response = new();

            // Get order and start filling in receipt-dto
            var order = await _orderRepository.GetByIdAsync(request.Id);

            GetReceiptResponse dto = new(order.Id, order.OrderDate, order.Employee.Alias);

            // Loop through each individual item
            foreach (var item in order.OrderRows)
            {
                var product = new ProductForReceipt(
                    ProductId: item.ProductId,
                    ProductName: item.Product.Name,
                    Price: item.Product.Price,
                    PriceWithoutVAT: item.Product.PriceBeforeVAT,
                    VAT: item.Product.VAT.Adjustment);

                dto.Products.Add(product);
            }
            // Add total price-calculation
            dto.Totalprice = dto.Products.Sum(x => x.Price);

            response.Data = dto;
            return await response.SuccessResponse(response, response.Data);
        }

        public async Task<ServiceResponse<List<ProductSaleCountDto>>> GetProductSaleCounts()
        {
            ServiceResponse<List<ProductSaleCountDto>> response = new();

            try
            {
                var productSaleCounts = await _orderRepository.GetProductSaleCount();
                response.Data = productSaleCounts;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product sale counts");
                return await response.ErrorResponse(response, "Failed to fetch product sale counts", _logger);
            }

            return await response.SuccessResponse(response, response.Data);
        }
        public async Task<ServiceResponse<List<OrderCountByHourDto>>> GetOrderStatsByUserChosenDate(DateTime selectedDate)
        {
            ServiceResponse<List<OrderCountByHourDto>> response = new ServiceResponse<List<OrderCountByHourDto>>();

            try
            {
                var orderStats = await _orderRepository.GetOrderStatsByDatePicked(selectedDate);
                response.Data = orderStats;
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                return await response.ErrorResponse(response, "Failed to fetch order stats", _logger);
            }

            return await response.SuccessResponse(response, response.Data);
        }

        public async Task<ServiceResponse<List<OrderCountDto>>> GetOrderStatsByDateRange(DateTime orderStartDate, DateTime orderEndDate)
        {
            ServiceResponse<List<OrderCountDto>> response = new ServiceResponse<List<OrderCountDto>>();

            try
            {
                var orderStats = await _orderRepository.GetOrderStatsByDateRange(orderStartDate, orderEndDate);
                response.Data = orderStats;
            }
            catch (Exception ex)
            {
                // Log and handle the exception
                return await response.ErrorResponse(response, "Failed to fetch order stats", _logger);
            }

            return await response.SuccessResponse(response, response.Data);
        }






    }
}
