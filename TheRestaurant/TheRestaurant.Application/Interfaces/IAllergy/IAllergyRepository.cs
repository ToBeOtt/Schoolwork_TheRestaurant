using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces.IAllergy
{
    public interface IAllergyRepository
    {
        Task AddAsync(Allergy allergy);
        Task<Allergy> GetByIdAsync(int id);
        Task UpdateAsync(Allergy allergy);
        Task DeleteAsync(int id);
        Task<List<Allergy>> GetAllAsync();
      
    }
}
