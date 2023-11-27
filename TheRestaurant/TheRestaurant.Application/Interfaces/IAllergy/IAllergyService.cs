using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Contracts.Requests.Allergy;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces.IAllergy
{
    public interface IAllergyService
    {
        Task<Allergy> CreateAllergyAsync(AllergyRequest request);
        Task<List<Allergy>> GetAllAllergies();
        Task<Allergy> GetAllergyById(int id);
        Task DeleteAllergyAsync(int id);
        Task<Allergy> UpdateAllergyAsync(int id, AllergyRequest request);
    }
}
