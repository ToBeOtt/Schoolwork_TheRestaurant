using Common.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using TheRestaurant.Domain.Entities.Authentication;

public class OrderEmployeeAssignmentService
{
    private readonly RestaurantDbContext _dbContext;
    private readonly UserManager<Employee> _userManager;

    public OrderEmployeeAssignmentService(RestaurantDbContext dbContext, UserManager<Employee> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    public async Task AssignEmployeesToOrdersAsync()
    {
        var employee = await _userManager.FindByEmailAsync("emp@mail.com");
        if (employee != null)
        {
            var ordersWithoutEmployee = _dbContext.Orders.Where(o => o.EmployeeId == null).ToList();
            foreach (var order in ordersWithoutEmployee)
            {
                order.EmployeeId = employee.Id;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
