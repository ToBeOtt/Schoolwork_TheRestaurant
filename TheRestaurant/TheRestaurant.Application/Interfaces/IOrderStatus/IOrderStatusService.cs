using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Contracts.DTOs;

namespace TheRestaurant.Application.Interfaces.IOrderStatus
{
    public interface IOrderStatusService
    {
        Task<OrderStatusDto> GetAsync(int id);
        Task<IReadOnlyList<OrderStatusDto>> GetAllAsync();
        Task<bool> AddAsync(OrderStatusDto orderStatusDto);
        Task<bool> UpdateAsync(OrderStatusDto orderStatusDto);
        Task<bool> DeleteAsync(int id);
        bool Exists(int id);
    }
}
