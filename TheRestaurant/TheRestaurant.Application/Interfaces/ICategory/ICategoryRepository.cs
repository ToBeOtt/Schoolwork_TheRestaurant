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
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> DeleteAsync(int id);
        Task SaveChangesAsync();
        bool Exists(int id);
    }
}
