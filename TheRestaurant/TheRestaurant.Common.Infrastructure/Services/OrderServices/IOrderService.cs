using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace Common.Infrastructure.Services.OrderServices
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetAllOrdersAsync();
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
    }
}