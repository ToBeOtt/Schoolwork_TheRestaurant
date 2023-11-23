using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Common.Infrastructure.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<Order> GetByIdAsync(int orderId);
        Task<List<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
        Task DeleteAsync(int orderId);
    }
}
