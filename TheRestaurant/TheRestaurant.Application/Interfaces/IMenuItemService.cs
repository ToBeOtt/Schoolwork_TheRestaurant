using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Contracts.Requests.Item;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces
{
    public interface IMenuItemService
    {
        Task<Item> CreateMenuItemAsync(CreateItemRequest request);

        Task<Item> GetMenuItemById(int id);
        Task<List<Item>> GetAllMenuItems();
        Task SoftDeleteMenuItemAsync(int id);

        Task<Item> UpdateMenuItemAsync(int id, EditItemRequest menuItem);
    }
}
