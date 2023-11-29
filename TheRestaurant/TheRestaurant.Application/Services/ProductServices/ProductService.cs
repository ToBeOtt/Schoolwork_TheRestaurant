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
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                MenuPhoto = request.MenuPhoto,
                IsFoodItem = request.IsFoodItem,
                IsDeleted = request.IsDeleted,
                ProductAllergies = new List<ProductAllergy>(),
                ProductCategories = new List<ProductCategory>()
            };

            foreach (var allergyId in request.SelectedAllergyIds)
            {
                product.ProductAllergies.Add(new ProductAllergy { AllergyId = allergyId });
            }

            foreach (var categoryId in request.SelectedCategoryIds)
            {
                product.ProductCategories.Add(new ProductCategory { CategoryId = categoryId });
            }

            await _productRepository.AddAsync(product);

            return product;
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            await _productRepository.SoftDeleteAsync(id);
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();

            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, EditProductRequest request)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(id);

            productToUpdate.Name = request.Name;
            productToUpdate.Description = request.Description;
            productToUpdate.MenuPhoto = request.MenuPhoto;
            productToUpdate.Price = request.Price;
            productToUpdate.IsFoodItem = request.IsFoodItem;
            productToUpdate.IsDeleted = request.IsDeleted;

            await _productRepository.UpdateAsync(productToUpdate);

            return productToUpdate;
        }
    }
}
