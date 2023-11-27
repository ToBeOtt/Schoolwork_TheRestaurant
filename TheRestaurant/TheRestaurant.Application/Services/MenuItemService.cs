﻿using System;
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

        public async Task<Item> CreateMenuItemAsync(CreateMenuItemRequest request)
        {
            var menuItem = new Item
            {
                Name = request.Name,
                Description = request.Description,
                MenuPhoto = request.MenuPhoto
                // Category & Allergy
            };

            await _menuItemRepository.AddAsync(menuItem);

            return menuItem;
        }

        public async Task DeleteMenuItemAsync(int id)
        {
            var menuItem = await _menuItemRepository.GetByIdAsync(id);

            if (menuItem != null)
            {
                await _menuItemRepository.DeleteAsync(menuItem.Id);
            }
            else
            {
                // Error handling
            }
           
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

        public async Task<Item> UpdateMenuItemAsync(int id, EditMenuItemRequest request)
        {
            var menuItemToUpdate = await _menuItemRepository.GetByIdAsync(id);

            menuItemToUpdate.Name = request.Name;
            menuItemToUpdate.Description = request.Description;
            menuItemToUpdate.MenuPhoto = request.MenuPhoto;

            await _menuItemRepository.UpdateAsync(menuItemToUpdate);

            return menuItemToUpdate;
        }
    }
}