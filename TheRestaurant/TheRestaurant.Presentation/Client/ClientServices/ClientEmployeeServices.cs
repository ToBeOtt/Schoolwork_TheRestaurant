using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;
using static TheRestaurant.Presentation.Client.Components.Admin.Employees.EmployeesDataGrid;
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
                    HireDate: emp.HireDate
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


    }
}
