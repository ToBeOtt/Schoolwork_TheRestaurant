using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Contracts.Requests.Product;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces.IProduct
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(CreateProductRequest request);

        Task<Product> GetProductById(int id);
        Task<List<Product>> GetAllProducts();
        Task SoftDeleteProductAsync(int id);

        Task<Product> UpdateProductAsync(int id, EditProductRequest menuItem);
    }
}
