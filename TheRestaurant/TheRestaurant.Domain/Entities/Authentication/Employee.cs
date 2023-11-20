using Microsoft.AspNetCore.Identity;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Domain.Entities.Authentication
{
    public sealed class Employee : IdentityUser
    {
        public string Alias { get; private set; }
        public ICollection<EmployeeOrder> Orders {  get; set; } 

        public Employee() { }

        public void CreateUser(string email, string alias)
        {
            Email = email;
            Alias = alias;
        }


        private void UpdateRole(Employee user)
        {
            throw new NotImplementedException();
        }
        private void DeleteUser(Employee user)
        {
            throw new NotImplementedException();
        }
    }
}
