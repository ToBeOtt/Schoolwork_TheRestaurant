using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces.ICategory;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Testing.Mocks
{
    public static class MockRepositoreis
    {
        public static  Mock<ICategoryRepository> GetMockCategoryRepository()
        {
            var categories = new List<Category>()
            {
                new Category { Id = 1, Name = "Appetizers", IsDeleted = false },
                new Category { Id = 2, Name = "Salads", IsDeleted = false },
                new Category { Id = 3, Name = "Soups", IsDeleted = true },
            };

            var mockRepo = new Mock<ICategoryRepository>();

            // GetAllAsync
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);

            // GetByIdAsync
            mockRepo.Setup(r => r.GetAsync((It.IsAny<int>()))).ReturnsAsync((int id) =>
            {
                var result = from c in categories where c.Id == id select c;
                var category = new Category { 
                    Id = id,
                    Name = result.First().Name,
                    IsDeleted = result.First().IsDeleted
                };

                return category;
            });


            // AddAsync   
            mockRepo.Setup(r => r.AddAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
            {
                categories.Add(category);
                return category;
            });

            // UpdateAsync
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<Category>())).ReturnsAsync((Category category) =>
            {
                //var result = from c in categories where c.Id == category.Id select c;
                //result.First().Name = category.Name;
                //result.First().IsDeleted = category.IsDeleted;
                return category;
            });

            // DeleteAsync
            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int categoryId) =>
            {
                var result = from c in categories where c.Id == categoryId select c;
                var category = new Category
                {
                    Id = categoryId,
                    Name = result.First().Name,
                    IsDeleted = result.First().IsDeleted
                };
                categories.Remove(category);
                return category;
            });


            // Exists
            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).Returns((int categoryId) =>
            {
                foreach (var item in categories)
                {
                    if (item.Id == categoryId)
                    {
                        return true;
                    }
                }
                return false;
            });

            return mockRepo;
        }
    }
}
