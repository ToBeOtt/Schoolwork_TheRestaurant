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

        public Task DeleteAllergyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Allergy>> GetAllAllergies()
        {
            throw new NotImplementedException();
        }

        public Task<Allergy> UpdateAllergyAsync(int id, AllergyRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
