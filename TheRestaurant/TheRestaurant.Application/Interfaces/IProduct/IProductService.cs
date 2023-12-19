using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Services.ProductServices.DTO;
using TheRestaurant.Contracts.DTOs.OrderDTOs;
using TheRestaurant.Contracts.Requests.Product;
using TheRestaurant.Contracts.Responses.ServiceResponse;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces.IProduct
{
    public interface IProductService
    {
        Task<Product> CreateProductAsync(CreateProductRequest request);

        Task<Product> GetProductById(int id);
        Task<ServiceResponse<List<ClientProductDto>>> GetAllProducts();
        Task<List<string>> FetchAllCategoryNames();
        Task SoftDeleteProductAsync(int id);

        Task<Product> UpdateProductAsync(int id, EditProductRequest menuItem);
    }
}
