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
        Task<MenuItem> CreateMenuItemAsync(CreateMenuItemRequest request);

        Task<MenuItem> GetMenuItemById(int id);
        Task<List<MenuItem>> GetAllMenuItems();
        Task DeleteMenuItemAsync(int id);

        Task<MenuItem> UpdateMenuItemAsync(int id, EditMenuItemRequest menuItem);
    }
}
