using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.DTOs;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Application.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderDTO orderDto);
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetAllOrdersAsync();
        Task UpdateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        void SetOrderStatus(Order order, string status);
    }

}
