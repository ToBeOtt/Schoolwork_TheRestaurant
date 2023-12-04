using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Contracts.DTOs;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Application.Interfaces.IOrderStatus
{
    public interface IOrderStatusService
    {
        Task<OrderStatusDto> GetAsync(int id);
        Task<IReadOnlyList<OrderStatusDto>> GetAllAsync();
        Task<bool> AddAsync(OrderStatusDto orderStatusDto);
        Task<bool> UpdateAsync(OrderStatusDto orderStatusDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> Disable(int id);
        Task<bool> Enable(int id);
        bool Exists(int id);
    }
}
