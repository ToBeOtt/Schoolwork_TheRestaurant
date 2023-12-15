using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheRestaurant.Application.Interfaces.IVat;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Common.Infrastructure.Repositories.Vat
{
    public class VatRepository : IVatRepository
    {
        private readonly RestaurantDbContext _context;
        public VatRepository(RestaurantDbContext context)
        {
            _context = context;
        }
        public async Task<VAT> AddAsync(VAT vat)
        {
            _context.VATs.Add(vat);
            await _context.SaveChangesAsync();
            return vat;
        }

        public async Task DeleteAsync(int id)
        {
            var vat = await _context.VATs.FindAsync(id);
            if (vat != null)
            {
                _context.VATs.Remove(vat);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<VAT>> GetAllAsync()
        {
            return await _context.VATs.ToListAsync();
        }

        public async Task<VAT> GetByIdAsync(int id)
        {
            return await _context.VATs.FindAsync(id);
        }

        public async Task UpdateAsync(VAT vat)
        {
            _context.VATs.Update(vat);
            await _context.SaveChangesAsync();
        }
    }
}
