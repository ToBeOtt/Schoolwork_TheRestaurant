using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Contracts.Requests.MenuItem;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [ApiController]
    [Route("admin/[controller]")]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateMenuItemRequest request)
        {
            try
            {
                var menuItem = await _menuItemService.CreateMenuItemAsync(request);
                return CreatedAtAction(nameof(GetMenuItem), new { id = menuItem.Id }, menuItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ett fel uppstod när menyalternativet skapades");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            var menuItem = await _menuItemService.GetMenuItemById(id);
            if (menuItem == null)
            {
                return NotFound();
            }

            return Ok(menuItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenuItems()
        {
            try
            {
                var menuItems = await _menuItemService.GetAllMenuItems();
                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ett fel uppstod när menyalternativen hämtades");
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            try
            {
                await _menuItemService.DeleteMenuItemAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ett fel uppstod närmenyalternativet skulle raderas");
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, EditMenuItemRequest request)
        {
            try
            {
                var menuItem = await _menuItemService.UpdateMenuItemAsync(id, request);
                if (menuItem == null)
                {
                    return NotFound();
                }
                return Ok(menuItem);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Ett fel uppstod när menyalternativet skulle uppdateras");
            }
        }
    }
}
