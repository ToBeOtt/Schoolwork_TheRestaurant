using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TheRestaurant.Contracts.Responses.ServiceResponse;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Authentication.Services.RoleServices
{
    public class RoleService
    {
        private readonly ILogger<RoleService> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Employee> _userManager;

        public RoleService(
            ILogger<RoleService> logger,
            RoleManager<IdentityRole> roleManager, 
            UserManager<Employee> userManager)
        {
            _logger = logger;
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task CreateRolesAsync()
        {
            await CreateRoleIfNotExistsAsync("Employee");
            await CreateRoleIfNotExistsAsync("Manager");
        }

        public async Task<ServiceResponse<bool>> AssignRoleToUserAsync(string userId, string roleName)
        {
            ServiceResponse<bool> response = new();

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return await response.ErrorResponse
                    (response, "User could not be found.", _logger, "User not found.");


            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                if (!await CreateRoleIfNotExistsAsync(roleName))
                {
                    return await response.ErrorResponse
                      (response, "Role could not be assigned.", _logger);
                }
            }
              
            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded)
                return await response.ErrorResponse
                  (response, "Role could not be assigned.", _logger);

           
            return await response.SuccessResponse
                  (response, true);
        }

        private async Task<bool> CreateRoleIfNotExistsAsync(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var outcome = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if(outcome.Succeeded)
                    return true;
                else 
                    return false;
            }
            return false;
        }
    }
}
