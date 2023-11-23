using TheRestaurant.Application.DTOs;


namespace TheRestaurant.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<CategoryDto>> GetAllAsync();
    }
}
