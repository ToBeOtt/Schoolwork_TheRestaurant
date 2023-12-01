using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Menu;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Application.Interfaces.IOrderStatus
{
    public interface IOrderStatusRepository
    {
        Task<OrderStatus> GetAsync(int id);
        Task<IReadOnlyList<OrderStatus>> GetAllAsync();
        Task AddAsync(OrderStatus orderStatus);
        Task UpdateAsync(OrderStatus orderStatus);
        Task DeleteAsync(OrderStatus orderStatus);
        Task DeleteAsync(int id);
        Task<bool> Disable(int id);
        Task<bool> Enable(int id);
        bool Exists(int id);
        Task SaveChangesAsync();
    }
}
