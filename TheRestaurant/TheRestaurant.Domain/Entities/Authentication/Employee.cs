using Microsoft.AspNetCore.Identity;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Domain.Entities.Authentication
{
    public sealed class Employee : IdentityUser
    {
        public string Alias { get; set; }
        public ICollection<EmployeeOrder> Orders {  get; set; } 
        public bool IsDeleted { get; set; }
        public DateTime EmploymentStarted { get; set; }
        public DateTime EmploymentEnded { get; private set; }

        public Employee() { }

        public void CreateUser(string email, string alias)
        {
            Email = email;
            Alias = alias;
            EmploymentStarted = DateTime.Now;
            IsDeleted = false;
    }

        public Employee LayoffEmployee(Employee employee)
        {
            employee.IsDeleted = true;
            employee.EmploymentEnded = DateTime.Now;
            return employee;
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
