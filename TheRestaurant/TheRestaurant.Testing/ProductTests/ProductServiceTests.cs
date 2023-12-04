using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Application.Services.ProductServices;
using TheRestaurant.Contracts.Requests.Product;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Testing.ProductTests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProductById_ShouldReturnProduct_ProductExists()
        {
            // Arrange
            var productId = 1;
            var expectedProduct = new Product
            {
                Id = productId,
                Name = "Test Product",
            };

            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(expectedProduct);

            var productService = new ProductService(mockRepo.Object);

            // Act
            var result = await productService.GetProductById(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedProduct, result);
        }

        [Fact]
        public async Task GetProductById_ShouldReturnNull_ProductDoesNotExist()
        {
            var productId = 1;
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync((Product)null);

            var productService = new ProductService(mockRepo.Object);

            var result = await productService.GetProductById(productId);
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateProduct_ShouldCreateProduct_ValidInput()
        {
            var createRequest = new CreateProductRequest(
                Name: "New Product",
                Price: 10.99,
                Description: "Description",
                MenuPhoto: new byte[0], // Assuming byte array for the photo
                IsFoodItem: true,
                IsDeleted: false,
                SelectedCategoryIds: new List<int>(), // Assuming list of category IDs
                SelectedAllergyIds: new List<int>()  // Assuming list of allergy IDs
            );



            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Product>()));

            var productService = new ProductService(mockRepo.Object);

            // Act
            await productService.CreateProductAsync(createRequest);

            // Assert
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);

        }
    }
}
