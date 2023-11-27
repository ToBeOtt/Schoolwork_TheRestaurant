using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Contracts.Requests.MenuItem;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces
{
    public interface IMenuItemService
    {
        Task<Item> CreateMenuItemAsync(CreateMenuItemRequest request);

        Task<Item> GetMenuItemById(int id);
        Task<List<Item>> GetAllMenuItems();
        Task DeleteMenuItemAsync(int id);

        Task<Item> UpdateMenuItemAsync(int id, EditMenuItemRequest menuItem);
    }
}
