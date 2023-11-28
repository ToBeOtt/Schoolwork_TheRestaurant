using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Application.Employees.Interfaces
{
    public interface IEmployeeRepository
    {
        //Commands
        Task<bool> Inactivate(Employee Employee);


        //Queries
        Task<Employee> GetEmployee(string id);
        Task<List<Employee>> GetAllEmployees();
    }
}
