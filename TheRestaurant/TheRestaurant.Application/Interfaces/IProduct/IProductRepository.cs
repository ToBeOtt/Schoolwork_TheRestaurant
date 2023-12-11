using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces.IProduct
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product menuItem);
        Task UpdateAsync(Product menuItem);
        Task SoftDeleteAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetAllEagerLoadedAsync();
        Task<List<string>> GetAllCategoryNames();

        // VATs
        Task<VAT> GetVATByName(string name);
        
    }
}
