using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Contracts.Requests.MenuItem;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IMenuItemRepository _menuItemRepository;
        public MenuItemService(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<MenuItem> CreateMenuItemAsync(CreateMenuItemRequest request)
        {
            var menuItem = new MenuItem
            {
                Name = request.Name,
                Description = request.Description,
                MenuPhoto = request.MenuPhoto
                // Category & Allergy
            };

            await _menuItemRepository.AddAsync(menuItem);

            return menuItem;
        }

        public async Task<MenuItem> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);

            return menuItem;
        }
    }
}
