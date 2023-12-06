using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Contracts.Requests.Order;
using TheRestaurant.Domain.Entities.Menu;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Application.Services.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public void SetOrderStatus(Order order, string status)
        {
            var orderStatus = new OrderStatus { Status = status };
            order.OrderStatus = orderStatus;
        }

        public OrderService(
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> CreateOrderAsync(CreateOrderRequest request)
        {

            // new order
            Order order = new();

            // Product and order row

            foreach(var item in request.ProductAggregate)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                for (int i = 0; i < item.ProductCount; i++)
                {
                    OrderRow orderRow = new(order, product);
                    if (!await _orderRepository.CreateOrderRow(orderRow))
                        throw new DbUpdateException();
                }
            }


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
