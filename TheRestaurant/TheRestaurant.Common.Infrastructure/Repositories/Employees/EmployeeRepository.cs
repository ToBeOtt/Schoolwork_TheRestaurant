using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheRestaurant.Application.Employees.Interfaces;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Common.Infrastructure.Repositories.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ILogger<EmployeeRepository> _logger;
        private readonly RestaurantDbContext _context;

        public EmployeeRepository
            (ILogger<EmployeeRepository> logger,
            RestaurantDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<Employee> GetEmployee(string id)
        {
            return await _context.Employees.Where(e => e.Id == id).SingleOrDefaultAsync();
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<bool> Inactivate(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return true;
        }
    }
}
