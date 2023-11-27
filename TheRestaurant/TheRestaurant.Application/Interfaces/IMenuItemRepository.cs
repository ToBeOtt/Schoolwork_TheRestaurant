using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<Item> GetByIdAsync(int id);
        Task AddAsync(Item menuItem);
        Task UpdateAsync(Item menuItem);
        Task SoftDeleteAsync(int id);
        Task<List<Item>> GetAllAsync();
    }
}
