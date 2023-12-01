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
                Name = category.Name
            };

            return categoryDto;

        }

        //Add New Category
        public async Task AddAsync(CategoryDto categoryDto)
        {
            Category category = new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
            };
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        //Update the Category
        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            Category category = new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
            };
            await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        //Delete the Category
        public async Task DeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public bool Exists(int id)
        {
            return _categoryRepository.Exists(id);
        }

    }
}
