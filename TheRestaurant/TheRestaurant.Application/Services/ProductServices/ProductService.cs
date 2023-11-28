using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Contracts.Requests.Product;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProductAsync(CreateProductRequest request)
        {
            var menuItem = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                MenuPhoto = request.MenuPhoto,
                IsFoodItem = request.IsFoodItem,
                IsDeleted = request.IsDeleted,
                ProductAllergies = new List<ProductAllergy>()
                // Category & Allergy
            };

            foreach (var allergyId in request.SelectedAllergyIds)
            {
                menuItem.ProductAllergies.Add(new ProductAllergy { AllergyId = allergyId });
            }

            await _productRepository.AddAsync(menuItem);

            return menuItem;
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            await _productRepository.SoftDeleteAsync(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var menuItems = await _productRepository.GetAllAsync();

            return menuItems;
        }

        public async Task<Product> GetProductById(int id)
        {
            var menuItem = await _productRepository.GetByIdAsync(id);

            return menuItem;
        }

        public async Task<Product> UpdateProductAsync(int id, EditProductRequest request)
        {
            var menuItemToUpdate = await _productRepository.GetByIdAsync(id);

            menuItemToUpdate.Name = request.Name;
            menuItemToUpdate.Description = request.Description;
            menuItemToUpdate.MenuPhoto = request.MenuPhoto;
            menuItemToUpdate.Price = request.Price;
            menuItemToUpdate.IsFoodItem = request.IsFoodItem;
            menuItemToUpdate.IsDeleted = request.IsDeleted;

            await _productRepository.UpdateAsync(menuItemToUpdate);

            return menuItemToUpdate;
        }
    }
}
