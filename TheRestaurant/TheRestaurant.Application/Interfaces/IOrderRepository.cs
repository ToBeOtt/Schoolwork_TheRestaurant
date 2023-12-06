using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);

        Task<bool> CreateOrderRow(OrderRow orderRow);
        Task<Order> GetByIdAsync(int orderId);
        Task<List<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
        Task DeleteAsync(int orderId);
    }
}
