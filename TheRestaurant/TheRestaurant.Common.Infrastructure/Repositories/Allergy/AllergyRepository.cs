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


        public async Task AddAsync(Domain.Entities.Menu.Allergy allergy)
        {
            try
            {
                _context.Add(allergy);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }



        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



        public async Task<List<Domain.Entities.Menu.Allergy>> GetAllAsync()
        {
            return await _context.Allergies.ToListAsync();
        }

        public async Task<Domain.Entities.Menu.Allergy> GetByIdAsync(int id)
        {
            return await _context.Allergies.FirstOrDefaultAsync(a => a.Id == id);
        }

        public Task UpdateAsync(Domain.Entities.Menu.Allergy allergy)
        {
            throw new NotImplementedException();
        }
    }
}
