using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public static class SeedRoles
    {
        public static void SeedData(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("admin").Result)
            {
                IdentityRole adminRole = new IdentityRole { Name = "admin" };
                IdentityResult roleResult = roleManager.CreateAsync(adminRole).Result;
            }

            if (!roleManager.RoleExistsAsync("manager").Result)
            {
                IdentityRole managerRole = new IdentityRole { Name = "manager" };
                IdentityResult roleResult = roleManager.CreateAsync(managerRole).Result;
            }
        }
    }
}
