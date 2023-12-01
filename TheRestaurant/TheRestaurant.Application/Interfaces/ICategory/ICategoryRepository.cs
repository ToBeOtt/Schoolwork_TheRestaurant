using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces.ICategory
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(int id);
        Task<IReadOnlyList<Category>> GetAllAsync();
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        bool Exists(int id);
    }
}
