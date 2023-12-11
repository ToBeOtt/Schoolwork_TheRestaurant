using TheRestaurant.Application.Interfaces.ICategory;
using TheRestaurant.Contracts.DTOs;
using TheRestaurant.Domain.Entities.Menu;


namespace TheRestaurant.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        // Get All Categories
        public async Task<IReadOnlyList<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories == null)
            {
                return null;
            }
            var categoryDtos = categories.Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
                IsDeleted = c.IsDeleted,
            }).ToList();

            return categoryDtos;
        }

        //Get Category By Id
        public async Task<CategoryDto> GetAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);
            if (category == null)
            {
                return null;
            }
            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                IsDeleted = category.IsDeleted
            };

            return categoryDto;

        }

        //Add New Category
        public async Task<bool> AddAsync(CategoryDto categoryDto)
        {
            try
            {
                Category category = new Category()
                {
                    Id = categoryDto.Id,
                    Name = categoryDto.Name,
                    IsDeleted = categoryDto.IsDeleted
                };
                await _categoryRepository.AddAsync(category);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

           
        }

        //Update the Category
        public async Task<bool> UpdateAsync(CategoryDto categoryDto)
        {

            try
            {
                Category category = new Category()
                {
                    Id = categoryDto.Id,
                    Name = categoryDto.Name,
                    IsDeleted = categoryDto.IsDeleted
                };
                await _categoryRepository.UpdateAsync(category);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // Delete By ID
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _categoryRepository.DeleteAsync(id);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            
        }

        // Exists
        public bool Exists(int id)
        {
            return _categoryRepository.Exists(id);
        }


        // Save Change
        private async Task SaveChangesAsync()
        {
            await _categoryRepository.SaveChangesAsync();
        }

    }
}
