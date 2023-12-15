using Moq;
using TheRestaurant.Application.Interfaces.ICategory;
using TheRestaurant.Application.Services;
using TheRestaurant.Contracts.DTOs;
using TheRestaurant.Domain.Entities.Menu;
using TheRestaurant.Testing.Mocks;

namespace TheRestaurant.Testing.CategoryTests
{
    public class CategoryServiceTests
    {
        readonly Mock<ICategoryRepository> _mockRepository;
        public CategoryServiceTests()
        {
            _mockRepository= MockRepositoreis.GetMockCategoryRepository();
        }

        [Fact]
        public async Task GetAllAsync()
        {
            // Arrange
            var categoryService = new CategoryService(_mockRepository.Object);

            // Act
            var result = await categoryService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);

        }

        [Fact]
        public async Task GetAsync()
        {
            // Arrange
            var categoryService = new CategoryService(_mockRepository.Object);

            // Act
            var result = await categoryService.GetAsync(2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Salads", result.Name);
            Assert.Equal(2, result.Id);

        }

        [Fact]
        public async Task AddAsync()
        {
            // Arrange
            var categoryService = new CategoryService(_mockRepository.Object);
            
            var newCategory = new CategoryDto { Id = 4, Name = "Pasta", IsDeleted = false };

            //// Act
            var added = await categoryService.AddAsync(newCategory);
            var result = await categoryService.GetAllAsync();

            // Assert
            Assert.Equal(true, added);
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);

        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var categoryService = new CategoryService(_mockRepository.Object);

            var newCategory = new CategoryDto { Id = 1, Name = "Lamb", IsDeleted = true };

            //// Act
            var updated = await categoryService.AddAsync(newCategory);

            // Assert
            Assert.NotNull(updated);
            Assert.Equal(true, updated);

        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Arrange
            var categoryService = new CategoryService(_mockRepository.Object);

            var categoryId = 1;

            //// Act
            var deleted = await categoryService.DeleteAsync(categoryId);

            // Assert
            Assert.NotNull(deleted);
            Assert.Equal(true, deleted);


        }

        [Fact]
        public async Task Exists()
        {
            // Arrange
            var categoryService = new CategoryService(_mockRepository.Object);

            var categoryId = 2;

            //// Act
            var exists = categoryService.Exists(categoryId);

            // Assert
            Assert.NotNull(exists);
            Assert.Equal(true, exists);


        }
   
    }
}
