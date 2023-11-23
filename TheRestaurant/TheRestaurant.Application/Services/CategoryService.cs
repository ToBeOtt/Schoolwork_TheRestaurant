using TheRestaurant.Application.DTOs;
using TheRestaurant.Application.Interfaces;


namespace TheRestaurant.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IReadOnlyList<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoryDtos = categories.Select(c => new CategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return categoryDtos;
        }
    }
}
