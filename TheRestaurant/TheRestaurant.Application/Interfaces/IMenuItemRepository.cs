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
        Task<MenuItem> GetByIdAsync(int id);
        Task AddAsync(MenuItem menuItem);
        Task UpdateAsync(MenuItem menuItem);
        Task DeleteAsync(int id);
        Task<List<MenuItem>> GetAllAsync();
    }
}
