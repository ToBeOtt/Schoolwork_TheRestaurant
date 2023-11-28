using TheRestaurant.Contracts.DTOs;


namespace TheRestaurant.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetAsync(int id);
        Task AddAsync(CategoryDto categoryDto);
        Task UpdateAsync(CategoryDto categoryDto);
        Task DeleteAsync(int id);
        bool Exists(int id);
    }
}
