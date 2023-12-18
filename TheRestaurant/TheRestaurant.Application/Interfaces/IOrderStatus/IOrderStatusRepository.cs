using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Application.Interfaces.IOrderStatus
{
    public interface IOrderStatusRepository
    {
        Task<OrderStatus> GetAsync(string status);
        Task<OrderStatus> GetAsync(int id);
        Task<IReadOnlyList<OrderStatus>> GetAllAsync();
        Task<OrderStatus> AddAsync(OrderStatus orderStatus);
        Task<OrderStatus> UpdateAsync(OrderStatus orderStatus);
        Task<OrderStatus> DeleteAsync(OrderStatus orderStatus);
        Task<OrderStatus> DeleteAsync(int id);
        bool Exists(int id);
        Task SaveChangesAsync();
    }
}
