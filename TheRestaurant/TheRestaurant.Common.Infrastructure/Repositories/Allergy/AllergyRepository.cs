using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces.IAllergy;
using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TheRestaurant.Common.Infrastructure.Repositories.Allergy
{
    public class AllergyRepository : IAllergyRepository
    {

        private readonly RestaurantDbContext _context;

        public AllergyRepository(RestaurantDbContext context)
        {
            _context = context;
        }


        public Task AddAsync(Domain.Entities.Menu.Allergy allergy)
        {
            throw new NotImplementedException();
        }



        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



        public Task<List<Domain.Entities.Menu.Allergy>> GetAllAsync()
        {
            throw new NotImplementedException();
        }


        public Task UpdateAsync(Domain.Entities.Menu.Allergy allergy)
        {
            throw new NotImplementedException();
        }
    }
}
