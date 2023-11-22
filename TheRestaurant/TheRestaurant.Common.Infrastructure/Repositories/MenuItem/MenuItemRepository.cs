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

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.Menu.MenuItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entities.Menu.MenuItem> GetByIdAsync(int id)
        {
            return await _context.MenuItems.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task UpdateAsync(Domain.Entities.Menu.MenuItem menuItem)
        {
            throw new NotImplementedException();
        }
    }
}
