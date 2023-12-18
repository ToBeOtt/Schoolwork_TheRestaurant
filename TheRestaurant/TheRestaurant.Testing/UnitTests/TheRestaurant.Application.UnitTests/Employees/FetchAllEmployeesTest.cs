using Microsoft.Extensions.Logging;
using Moq;
using TheRestaurant.Application.Cart;
using TheRestaurant.Application.Cart.Interfaces;
using TheRestaurant.Application.Employees;
using TheRestaurant.Application.Employees.Interfaces;
using TheRestaurant.Contracts.Responses;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Testing.UnitTests.TheRestaurant.Application.UnitTests.Employees
{
    public class FetchAllEmployeesTest
    {
        [Fact]
        public async Task FetchAllEmployees_Success_ReturnsValidResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<EmployeeServices>>();
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            var empList = new List<Employee>
            {
                new Employee {Email = "test@mail.com", Alias = "TestMock1"},
                new Employee {Email = "test2@mail.com", Alias = "TestMock2"},
            };

            employeeRepositoryMock.Setup
                (repo => repo.GetAllEmployees()).ReturnsAsync(empList);

            var empService = new EmployeeServices(
                loggerMock.Object,
                employeeRepositoryMock.Object
            );

            // Act
            var result = await empService.FetchAllEmployees();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Data);
            Assert.Equal(empList.Count, result.Data.Count);
        }


        [Fact]
        public async Task FetchAllEmployees_NoEmployeesFound_ReturnsErrorResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<EmployeeServices>>();
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            employeeRepositoryMock.Setup
                (repo => repo.GetAllEmployees()).ReturnsAsync((List<Employee>)null);

            var empService = new EmployeeServices(
               loggerMock.Object,
               employeeRepositoryMock.Object
               );

            // Act
            var result = await empService.FetchAllEmployees();

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Null(result.Data);
            Assert.Equal("Employees could not be found", result.ErrorMessage);
        }
    }
}
