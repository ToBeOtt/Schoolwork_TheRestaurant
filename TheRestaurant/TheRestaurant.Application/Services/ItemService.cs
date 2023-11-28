using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Contracts.Requests.Item;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _menuItemRepository;
        public ItemService(IItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<Item> CreateMenuItemAsync(CreateItemRequest request)
        {
            var menuItem = new Item
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                MenuPhoto = request.MenuPhoto,
                IsFoodItem = request.IsFoodItem,
                IsDeleted = request.IsDeleted,
                MenuItemAllergies = new List<MenuItemAllergy>()
                // Category & Allergy
            };

            foreach (var allergyId in request.SelectedAllergyIds)
            {
                menuItem.MenuItemAllergies.Add(new MenuItemAllergy { AllergyId = allergyId });
            }

            await _menuItemRepository.AddAsync(menuItem);

            return menuItem;
        }

        public async Task SoftDeleteMenuItemAsync(int id)
        {
                await _menuItemRepository.SoftDeleteAsync(id);
        }

        public async Task<List<Item>> GetAllMenuItems()
        {
            var menuItems = await _menuItemRepository.GetAllAsync();

            return menuItems;
        }

        public async Task<Item> GetMenuItemById(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);

            return menuItem;
        }

        public async Task<Item> UpdateMenuItemAsync(int id, EditItemRequest request)
        {
            var menuItemToUpdate = await _menuItemRepository.GetByIdAsync(id);

            menuItemToUpdate.Name = request.Name;
            menuItemToUpdate.Description = request.Description;
            menuItemToUpdate.MenuPhoto = request.MenuPhoto;
            menuItemToUpdate.Price = request.Price;
            menuItemToUpdate.IsFoodItem = request.IsFoodItem;
            menuItemToUpdate.IsDeleted = request.IsDeleted;

            await _menuItemRepository.UpdateAsync(menuItemToUpdate);

            return menuItemToUpdate;
        }
    }
}
