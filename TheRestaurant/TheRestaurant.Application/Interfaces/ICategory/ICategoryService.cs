using TheRestaurant.Contracts.DTOs;


namespace TheRestaurant.Application.Interfaces.ICategory
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetAsync(int id);
        Task<bool> AddAsync(CategoryDto categoryDto);
        Task<bool> UpdateAsync(CategoryDto categoryDto);
        Task<bool> DeleteAsync(int id);
        bool Exists(int id);
    }
}
