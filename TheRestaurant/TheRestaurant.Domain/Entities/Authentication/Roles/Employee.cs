using Microsoft.AspNetCore.Identity;

namespace TheRestaurant.Domain.Entities.Authentication.Roles
{
    public class Employee : IdentityRole
    {
        public Employee() : base("Employee")
        {
        }
    }
}
