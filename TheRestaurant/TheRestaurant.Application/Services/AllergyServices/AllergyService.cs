using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Application.Interfaces.IAllergy;
using TheRestaurant.Contracts.Requests.Allergy;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Services.AllergyServices
{
    public class AllergyService : IAllergyService
    {
        private readonly IAllergyRepository _allergyRepository;

        public AllergyService(IAllergyRepository allergyRepository)
        {
            _allergyRepository = allergyRepository;
        }

        public async Task<Allergy> CreateAllergyAsync(AllergyRequest request)
        {
            var allergy = new Allergy
            {
                Name = request.Name
            };

            await _allergyRepository.AddAsync(allergy);

            return allergy;
           
        }

        public async Task DeleteAllergyAsync(int id)
        {
            var allergyToDelete =  await GetAllergyById(id);
            await _allergyRepository.DeleteAsync(allergyToDelete);
        }

        public async Task<List<Allergy>> GetAllAllergies()
        {
            return await _allergyRepository.GetAllAsync();
        }

        public Task<Allergy> GetAllergyById(int id)
        {
            var allergy = _allergyRepository.GetByIdAsync(id);

            return allergy;
        }

        public async Task<Allergy> UpdateAllergyAsync(int id, AllergyRequest request)
        {
            var allergyToUpdate = await GetAllergyById(id);

            allergyToUpdate.Name = request.Name;

            await _allergyRepository.UpdateAsync(allergyToUpdate);
            return allergyToUpdate;
        }
    }
}
