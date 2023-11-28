using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public class UserSeeds
    {
        private readonly UserManager<Employee> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserSeeds(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedManager()
        {
            if (!await _roleManager.RoleExistsAsync("manager"))
            {
                await _roleManager.CreateAsync(new IdentityRole("manager"));
            }

            var manager = await _userManager.FindByNameAsync("TheBoss");

            if (manager == null)
            {
                manager = new Employee
                {
                    UserName = "TheBoss",
                    Alias = "TheBoss",
                    Email = "manager@mail.com",
                    EmploymentStarted = DateTime.Now,
                };

                await _userManager.CreateAsync(manager, "Manager11!");
                await _userManager.AddToRoleAsync(manager, "manager");
            }
        }

        public async Task SeedEmployee()
        {
            if (!await _roleManager.RoleExistsAsync("admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
            }

            var employee = await _userManager.FindByNameAsync("TheEmployee");

            if (employee == null)
            {
                employee = new Employee
                {
                    UserName = "TheEmployee",
                    Alias = "TheEmployee",
                    Email = "emp@mail.com"
                };

                await _userManager.CreateAsync(employee, "Admin11!");
                await _userManager.AddToRoleAsync(employee, "admin");
            }
        }
    }
}
