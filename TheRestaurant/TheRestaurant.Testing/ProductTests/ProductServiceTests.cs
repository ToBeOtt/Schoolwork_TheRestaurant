
using Moq;
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
                PriceBeforeVat: 10.99,
                Description: "Description",
                MenuPhoto: new byte[0],
                IsFoodItem: true,
                IsDeleted: false,
                SelectedCategoryIds: new List<int>(),
                SelectedAllergyIds: new List<int>(),
                VATId: 1
            );

            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Product>()));

            var productService = new ProductService(mockRepo.Object);

            // Act
            await productService.CreateProductAsync(createRequest);

            // Assert
            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);

        }

        [Fact]
        public async Task UpdateProduct_ShouldUpdateProduct_ProductExists()
        {
            var existingProduct = new Product
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
                Price = 100,
                MenuPhoto = new byte[0],
                IsDeleted = false,
                IsFoodItem = true,
            };

            var updatedProductRequest = new EditProductRequest(
                Name: "Updated Product",
                PriceBeforeVat: 200,
                Description: "Updated Description",
                MenuPhoto: new byte[0],
                IsFoodItem: true,
                IsDeleted: false,
                SelectedCategoryIds: new List<int>(),
                SelectedAllergyIds: new List<int>(),
                VatId: 1
                );

            var mockRepo = new Mock<IProductRepository>();


            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync(existingProduct);

            // Mock UpdateAsync to simulate updating the existing product 
            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Product>()))
                    .Callback<Product>(updatedProduct => existingProduct = updatedProduct);

            var productService = new ProductService(mockRepo.Object);

            await productService.UpdateProductAsync(existingProduct.Id, updatedProductRequest);

            Assert.Equal(updatedProductRequest.Name, existingProduct.Name);
            mockRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Product>()), Times.Once);
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

            Assert.Equal(products[1].Id , secondDto.Id);
            Assert.Equal(products[1].Name, secondDto.Name);
        }
    }
}
﻿//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TheRestaurant.Application.Interfaces.IProduct;
//using TheRestaurant.Application.Services.ProductServices;
//using TheRestaurant.Contracts.Requests.Product;
//using TheRestaurant.Domain.Entities.Menu;

//namespace TheRestaurant.Testing.ProductTests
//{
//    public class ProductServiceTests
//    {
//        [Fact]
//        public async Task GetProductById_ShouldReturnProduct_ProductExists()
//        {
//            Arrange
//           var productId = 1;
//            var expectedProduct = new Product
//            {
//                Id = productId,
//                Name = "Test Product",
//            };

//            var mockRepo = new Mock<IProductRepository>();
//            mockRepo.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync(expectedProduct);

//            var productService = new ProductService(mockRepo.Object);

//            Act
//           var result = await productService.GetProductById(productId);

//            Assert
//            Assert.NotNull(result);
//            Assert.Equal(expectedProduct, result);
//        }

//        [Fact]
//        public async Task GetProductById_ShouldReturnNull_ProductDoesNotExist()
//        {
//            var productId = 1;
//            var mockRepo = new Mock<IProductRepository>();
//            mockRepo.Setup(repo => repo.GetByIdAsync(productId)).ReturnsAsync((Product)null);

//            var productService = new ProductService(mockRepo.Object);

//            var result = await productService.GetProductById(productId);
//            Assert.Null(result);
//        }

//        [Fact]
//        public async Task CreateProduct_ShouldCreateProduct_ValidInput()
//        {
//            var createRequest = new CreateProductRequest(
//                Name: "New Product",
//                Price: 10.99,
//                Description: "Description",
//                MenuPhoto: new byte[0],
//                IsFoodItem: true,
//                IsDeleted: false,

//                SelectedAllergyIds: new List<int>()
//                SelectedAllergyIds: new List<int>()
//            );



//            var mockRepo = new Mock<IProductRepository>();
//            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Product>()));

//            var productService = new ProductService(mockRepo.Object);

//            // Act
//            await productService.CreateProductAsync(createRequest);

//            // Assert
//            mockRepo.Verify(repo => repo.AddAsync(It.IsAny<Product>()), Times.Once);

//        }

//        [Fact]
//        public async Task UpdateProduct_ShouldUpdateProduct_ProductExists()
//        {
//            var existingProduct = new Product
//            {
//                Id = 1,
//                Name = "Name",
//                Description = "Description",
//                Price = 100,
//                MenuPhoto = new byte[0],
//                IsDeleted = false,
//                IsFoodItem = true,
//            };

//            var updatedProductRequest = new EditProductRequest(
//                Name: "Updated Product",
//                PriceBeforeVat: 200,
//                Description: "Updated Description",
//                MenuPhoto: new byte[0],
//                IsFoodItem: true,
//                IsDeleted: false,
//                SelectedCategoryIds: new List<int>(),
//                SelectedAllergyIds: new List<int>()
//                );


//            var mockRepo = new Mock<IProductRepository>();


//            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
//                    .ReturnsAsync(existingProduct);

//            // Mock UpdateAsync to simulate updating the existing product 
//            mockRepo.Setup(repo => repo.UpdateAsync(It.IsAny<Product>()))
//                    .Callback<Product>(updatedProduct => existingProduct = updatedProduct);

//            var productService = new ProductService(mockRepo.Object);

//            await productService.UpdateProductAsync(existingProduct.Id, updatedProductRequest);

//            Assert.Equal(updatedProductRequest.Name, existingProduct.Name);
//            mockRepo.Verify(repo => repo.UpdateAsync(It.IsAny<Product>()), Times.Once);
//        }
//        [Fact]
//        public async Task SoftDeleteProduct_ShouldMarkproductAsDeleted()
//        {
//            var productId = 1;
//            var product = new Product
//            {
//                Id = productId,
//                Name = "Test Product",
//                IsDeleted = false // Initially, the product is not deleted
//            };

//            var mockRepo = new Mock<IProductRepository>();
//            mockRepo.Setup(repo => repo.SoftDeleteAsync(productId))
//                    .Callback<int>(id => product.IsDeleted = true);

//            var productService = new ProductService(mockRepo.Object);

//            await productService.SoftDeleteProductAsync(productId);


//            Assert.True(product.IsDeleted);
//            mockRepo.Verify(repo => repo.SoftDeleteAsync(productId), Times.Once);
//        }

//        [Fact]
//        public async Task GetAllProducts_ShouldReturnProducts_ProductsExists()
//        {
//            var products = new List<Product>
//            {
//                new Product
//                {
//                    Id = 1,
//                    Name = "Product 1",
//                    Price = 100,
//                    IsFoodItem = true,
//                    Description = "Description 1",
//                    MenuPhoto = new byte[0],
//                    ProductAllergies = new List<ProductAllergy>
//                    {
//                        new ProductAllergy { Allergy = new Allergy { Name = "Allergy 1" } }
//                    },
//                    ProductCategories = new List<ProductCategory>
//                    {
//                        new ProductCategory { Category = new Category { Name = "Category 1" } }
//                    }
//                },

//                new Product
//                {
//                    Id = 2,
//                    Name = "Product 2",
//                    Price = 50,
//                    IsFoodItem = true,
//                    Description = "Description 2",
//                    MenuPhoto = new byte[0],
//                    ProductAllergies = new List<ProductAllergy>
//                    {
//                        new ProductAllergy { Allergy = new Allergy { Name = "Allergy 2"} }
//                    },
//                    ProductCategories = new List<ProductCategory>
//                    {
//                        new ProductCategory { Category = new Category { Name = "Category 2"} }
//                    }
//                }
//            };

//            var mockRepo = new Mock<IProductRepository>();
//            mockRepo.Setup(repo => repo.GetAllEagerLoadedAsync()).ReturnsAsync(products);


//            var productService = new ProductService(mockRepo.Object);

//            var response = await productService.GetAllProducts();

//            Assert.NotNull(response);
//            Assert.NotNull(response.Data);
//            Assert.Equal(products.Count, response.Data.Count);

//            var firstDto = response.Data[0];

//            Assert.Equal(products[0].Id, firstDto.Id);
//            Assert.Equal(products[0].Name, firstDto.Name);

//            var secondDto = response.Data[1];

//            Assert.Equal(products[1].Id, secondDto.Id);
//            Assert.Equal(products[1].Name, secondDto.Name);
//        }
//    }
//}

