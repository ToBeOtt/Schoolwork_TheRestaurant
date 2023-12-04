using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TheRestaurant.Presentation.Shared.DTO.Employees;
using static TheRestaurant.Presentation.Shared.Requests.EmployeeRequests;

namespace TheRestaurant.Presentation.Client.ClientServices
{
    public class ClientEmployeeServices
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;


        public ClientEmployeeServices
            (HttpClient httpClient,
            NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public async Task<List<EmployeeDto>> GetAllEmployees(List<EmployeeDto> Employees)
        {
            var apiUrl = "/managerHome/GetAllEmployees";
            var listOfEmp = await _httpClient.GetFromJsonAsync<List<EmployeeDto>>(apiUrl);

            foreach (var emp in listOfEmp)
            {
                EmployeeDto empDto = new(
                    Id: emp.Id,
                    Alias: emp.Alias,
                    Email: emp.Email,
                    HireDate: emp.HireDate,
                    FireDate: emp.FireDate,
                    IsDeleted: emp.IsDeleted,
                    IsOnParentalLeave: emp.IsOnParentalLeave,
                    ParentalLeaveStartDate: emp.ParentalLeaveStartDate
                    );
                Employees.Add(empDto);
            }
            return Employees;
        }

        public async Task<bool> DeleteEmployee(string employeeId)
        {
            DeleteEmployeeRequest request = new(Id: employeeId);
            var json = JsonSerializer.Serialize(request);

            var apiUrl = "/managerHome/RemoveEmployee";

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
                return false;

        }

        public async Task<List<EmployeeDto>> FilterEmployees
            (int value, List<EmployeeDto> listToFilter)
        {
            switch (value)
            {
                case 0: // All employees
                    return listToFilter.Where(x => x.IsDeleted == false).ToList();

                case 1: // Employees no longer employed
                    return listToFilter.Where(x => x.IsDeleted == true).ToList();

                case 2: // Employees on parental leave
                    return listToFilter.Where(x => x.IsOnParentalLeave == true).ToList();

                default:
                    return listToFilter;
            }
        }
    }
}
