using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;
using TheRestaurant.Application.Employees.DTOs;
using TheRestaurant.Application.Employees.Interfaces;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Application.Employees
{
    public class EmployeeServices
    {
        private readonly ILogger<EmployeeServices> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeServices
            (ILogger<EmployeeServices> logger,
            IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task<ServiceResponse<bool>> RemoveEmployee(string userId)
        {
            ServiceResponse<bool> response = new();
            var emp = await _employeeRepository.GetEmployee(userId);
            if(emp == null)
                return await response.ErrorResponse
                    (response, "Employee could not be found", _logger);

            emp = emp.LayoffEmployee(emp);

            if (!await _employeeRepository.Inactivate(emp))
                return await response.ErrorResponse
                       (response, "Employee could not be deleted", _logger);

            return await response.SuccessResponse(response, true);
        }

        public async Task<ServiceResponse<ICollection<FetchEmployeeResponse>>> FetchAllEmployees()
        {
            ServiceResponse<ICollection<FetchEmployeeResponse>> response = new();
            var empList = await _employeeRepository.GetAllEmployees();
            if (empList == null)
                return await response.ErrorResponse
                    (response, "Employees could not be found", _logger);

            List<FetchEmployeeResponse> listOfDto = new List<FetchEmployeeResponse>();
            foreach (var emp in empList)
            {
                listOfDto.Add(
                   new FetchEmployeeResponse
                    (
                       Id: emp.Id,
                       Alias: emp.Alias,
                       Email: emp.Email,
                       HireDate: emp.EmploymentStarted,
                       FireDate: emp.EmploymentEnded,
                       IsDeleted: emp.IsDeleted,
                       IsOnParentalLeave: emp.ParentalLeave,
                       ParentalLeaveStartDate: emp.ParentalLeaveStarted
                   ));
            }

            response.Data = listOfDto;
            return await response.SuccessResponse(response, response.Data);
        }
    }
}
