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
            catch (DbUpdateException ex)
            {

                throw ex;
            }
            
        }



        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



        public async Task<List<Domain.Entities.Menu.Allergy>> GetAllAsync()
        {
            try
            {
                return await _context.Allergies.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<Domain.Entities.Menu.Allergy> GetByIdAsync(int id)
        {
            return await _context.Allergies.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Domain.Entities.Menu.Allergy allergy)
        {
            try
            {
                _context.Update(allergy);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

                throw ex;
            }
        }
    }
}
