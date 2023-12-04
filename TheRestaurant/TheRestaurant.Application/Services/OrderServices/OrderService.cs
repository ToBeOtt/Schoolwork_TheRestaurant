using TheRestaurant.Application.DTOs;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Application.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public void SetOrderStatus(Order order, string status)
        {
            var orderStatus = new OrderStatus { Status = status };
            order.OrderStatus = orderStatus;
        }

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrderAsync(OrderDTO orderDto)
        {
            var order = new Order
            {
                OrderDate = orderDto.OrderDate,
                // Map other properties from the DTO to the Order entity
            };

            // Assume that EmployeeOrders and OrderStatus are handled inside the repository
            return await _orderRepository.CreateAsync(order);
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
            // Implement the logic to update an order (e.g., validation)
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            // Implement the logic to delete an order (e.g., validation)
            await _orderRepository.DeleteAsync(orderId);
        }
    }
}
