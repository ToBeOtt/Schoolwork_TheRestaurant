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
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            var vat = new VAT { Adjustment = 1.06 }; // Example VAT value
            mockRepo.Setup(repo => repo.GetVATById(It.IsAny<int>())).ReturnsAsync(vat);
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Product>())).Verifiable();

            var productService = new ProductService(mockRepo.Object);

            var createRequest = new CreateProductRequest(
                Name: "New Product",
                PriceBeforeVat: 100,
                Description: "Test Description",
                MenuPhoto: new byte[0],
                IsFoodItem: true,
                IsDeleted: false,
                SelectedAllergyIds: new List<int> { 1, 2 },
                SelectedCategoryIds: new List<int> { 3, 4 },
                VATId: 1
            );

            // Act
            var resultProduct = await productService.CreateProductAsync(createRequest);

            // Assert
            mockRepo.Verify(repo => repo.GetVATById(It.IsAny<int>()), Times.Once);
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);

            Assert.NotNull(resultProduct);
            Assert.Equal(createRequest.Name, resultProduct.Name);
            Assert.Equal(createRequest.PriceBeforeVat, resultProduct.PriceBeforeVAT);
            Assert.Equal(createRequest.Description, resultProduct.Description);
            Assert.Equal(createRequest.IsFoodItem, resultProduct.IsFoodItem);
            Assert.Equal(createRequest.IsDeleted, resultProduct.IsDeleted);
            Assert.Equal(106, resultProduct.Price); // Check if VAT is applied correctly, Vat is 1.06 so price should come out to 106
            Assert.Equal(vat, resultProduct.VAT);
            Assert.NotNull(resultProduct.ProductAllergies);
            Assert.NotNull(resultProduct.ProductCategories);
            Assert.Equal(createRequest.SelectedAllergyIds?.Count, resultProduct.ProductAllergies.Count);
            Assert.Equal(createRequest.SelectedCategoryIds.Count, resultProduct.ProductCategories.Count);
        }

        [Fact]
        public async Task UpdateProduct_ShouldUpdateProduct_ValidInput()
        {
            // Arrange
            var existingProduct = new Product
            {
                Id = 1,
                Name = "Old Product",
                PriceBeforeVAT = 100,
                Description = "Old Description",
                MenuPhoto = new byte[0],
                IsFoodItem = false,
                IsDeleted = true,
                ProductCategories = new List<ProductCategory>(),
                ProductAllergies = new List<ProductAllergy>(),
                VATId = 1,
                VAT = new VAT { Adjustment = 1.12 }
            };

            var mockRepo = new Mock<IProductRepository>();
            var newVAT = new VAT { Adjustment = 1.06, Id = 1 };
            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingProduct);
            mockRepo.Setup(repo => repo.GetVATById(It.IsAny<int>())).ReturnsAsync(newVAT);
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Product>())).Verifiable();

            var productService = new ProductService(mockRepo.Object);

            var editRequest = new EditProductRequest(
                Name: "Updated Product",
                PriceBeforeVat: 200,
                Description: "Updated Description",
                MenuPhoto: new byte[1], // Assuming non-empty byte array
                IsFoodItem: true,
                IsDeleted: false,
                SelectedAllergyIds: new List<int> { 3, 4 },
                SelectedCategoryIds: new List<int> { 5, 6 },
                VatId: 1
            );

            // Act
            var updatedProduct = await productService.UpdateProductAsync(existingProduct.Id, editRequest);

            // Assert
            mockRepo.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once);
            mockRepo.Verify(repo => repo.GetVATById(It.IsAny<int>()), Times.Once);
            mockRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Product>()), Times.Once);

            Assert.NotNull(updatedProduct);
            Assert.Equal(editRequest.Name, updatedProduct.Name);
            Assert.Equal(editRequest.PriceBeforeVat, updatedProduct.PriceBeforeVAT);
            Assert.Equal(editRequest.Description, updatedProduct.Description);
            Assert.Equal(editRequest.IsFoodItem, updatedProduct.IsFoodItem);
            Assert.Equal(editRequest.IsDeleted, updatedProduct.IsDeleted);
            Assert.Equal(212, updatedProduct.Price); // Check if VAT is applied correctly, 1.06 VAT, price should be 212
            Assert.Equal(newVAT.Id, updatedProduct.VATId);
            Assert.Equal(newVAT, updatedProduct.VAT);
            Assert.NotNull(updatedProduct.ProductAllergies);
            Assert.NotNull(updatedProduct.ProductCategories);
            Assert.Equal(editRequest.SelectedAllergyIds.Count, updatedProduct.ProductAllergies.Count);
            Assert.Equal(editRequest.SelectedCategoryIds.Count, updatedProduct.ProductCategories.Count);
        }

        [Fact]
        public async Task SoftDeleteProduct_ShouldMarkproductAsDeleted()
        {
            var productId = 1;
            var product = new Product
            {
                Id = productId,
                Name = "Test Product",
                IsDeleted = false // Initially, the product is not deleted
            };

            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.SoftDeleteAsync(productId))
                    .Callback<int>(id => product.IsDeleted = true);

            var productService = new ProductService(mockRepo.Object);

            await productService.SoftDeleteProductAsync(productId);


            Assert.True(product.IsDeleted);
            mockRepo.Verify(repo => repo.SoftDeleteAsync(productId), Times.Once);
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnProducts_ProductsExists()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Price = 100,
                    IsFoodItem = true,
                    Description = "Description 1",
                    MenuPhoto = new byte[0],
                    ProductAllergies = new List<ProductAllergy>
                    {
                        new ProductAllergy { Allergy = new Allergy { Name = "Allergy 1" } }
                    },
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory { Category = new Category { Name = "Category 1" } }
                    }
                },

                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Price = 50,
                    IsFoodItem = true,
                    Description = "Description 2",
                    MenuPhoto = new byte[0],
                    ProductAllergies = new List<ProductAllergy>
                    {
                        new ProductAllergy { Allergy = new Allergy { Name = "Allergy 2"} }
                    },
                    ProductCategories = new List<ProductCategory>
                    {
                        new ProductCategory { Category = new Category { Name = "Category 2"} }
                    }
                }
            };

            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAllEagerLoadedAsync()).ReturnsAsync(products);


            var productService = new ProductService(mockRepo.Object);

            var response = await productService.GetAllProducts();

            Assert.NotNull(response);
            Assert.NotNull(response.Data);
            Assert.Equal(products.Count, response.Data.Count);

            var firstDto = response.Data[0];

            Assert.Equal(products[0].Id, firstDto.Id);
            Assert.Equal(products[0].Name, firstDto.Name);

            var secondDto = response.Data[1];

            Assert.Equal(products[1].Id, secondDto.Id);
            Assert.Equal(products[1].Name, secondDto.Name);
        }
    }
}
