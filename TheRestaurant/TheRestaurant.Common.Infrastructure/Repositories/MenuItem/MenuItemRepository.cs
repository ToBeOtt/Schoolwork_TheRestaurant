using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces;

namespace TheRestaurant.Common.Infrastructure.Repositories.MenuItem
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestaurantDbContext _context;

        public MenuItemRepository(RestaurantDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Domain.Entities.Menu.MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var itemToDelete = await _context.MenuItems.FindAsync(id);
            _context.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Domain.Entities.Menu.MenuItem>> GetAllAsync()
        {
            return await _context.MenuItems.ToListAsync();
        }

        public async Task<Domain.Entities.Menu.MenuItem> GetByIdAsync(int id)
        {
            return await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateAsync(Domain.Entities.Menu.MenuItem menuItem)
        {
            _context.Update(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}
