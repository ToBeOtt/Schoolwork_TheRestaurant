using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces;

namespace TheRestaurant.Common.Infrastructure.Repositories.Item
{
    public class ItemRepository : IItemRepository
    {
        private readonly RestaurantDbContext _context;

        public ItemRepository(RestaurantDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Domain.Entities.Menu.Item menuItem)
        {
            _context.Items.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(int id)
        {
            var itemToDelete = await _context.Items.FindAsync(id);
            if (itemToDelete != null)
            {
                itemToDelete.IsDeleted = true;
                _context.Items.Update(itemToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Error handling
            }
        }

        public async Task<List<Domain.Entities.Menu.Item>> GetAllAsync()
        {
            return await _context.Items.Where(item => !item.IsDeleted).ToListAsync();
        }

        public async Task<Domain.Entities.Menu.Item> GetByIdAsync(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Domain.Entities.Menu.Item menuItem)
        {
            _context.Update(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}
