using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces.IAllergy
{
    public interface IAllergyRepository
    {
        Task AddAllergyAsync(Allergy allergy);
        Task UpdateAllergyAsync(Allergy allergy);
        Task DeleteAllergyAsync(int id);
        Task<List<Allergy>> GetAllAllergiesAsync();
      
    }
}
