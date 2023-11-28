using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public static class SeedEmployees
    {
        public static void EmployeeSeed(this ModelBuilder modelBuilder, UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {
            {
                SeedRoles.SeedData(roleManager);

                List<Employee> employees = new List<Employee>();

                Employee boss = new Employee { UserName = "TheBoss", Alias = "Peanuts", Email = "manager@mail.com",};
                employees.Add(boss);

                Employee emp = new Employee{ UserName = "TheEmployee",Alias = "TheEmployee", Email = "employee2@mail.com", };
                employees.Add(emp);
                Employee apple = new Employee { UserName = "Äpplet", Alias = "Äpplet", Email = "apple@mail.com", IsDeleted = true};
                employees.Add(apple);
                Employee pear = new Employee { UserName = "Päronet", Alias = "Päronet", Email = "pear@mail.com", ParentalLeave = true};
                employees.Add(pear);
                Employee banana = new Employee { UserName = "Bananen", Alias = "Bananen", Email = "banana@mail.com", };
                employees.Add(banana);

                modelBuilder.Entity<Employee>().HasData(employees.ToArray());

                foreach (var employee in employees)
                {
                    if (userManager.FindByNameAsync(employee.UserName).Result != null)
                    {
                        if(employee.UserName == "TheBoss")
                            userManager.AddToRoleAsync(employee, "manager").Wait();
                        else
                            userManager.AddToRoleAsync(employee, "admin").Wait();
                    }
                }

            }
        } 
    }
}
