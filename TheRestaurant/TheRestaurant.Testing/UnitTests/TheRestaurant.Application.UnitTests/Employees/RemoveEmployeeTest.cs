using Microsoft.Extensions.Logging;
using Moq;
using TheRestaurant.Application.Employees;
using TheRestaurant.Application.Employees.Interfaces;
using TheRestaurant.Domain.Entities.Authentication;

namespace TheRestaurant.Testing.UnitTests.TheRestaurant.Application.UnitTests.Employees
{
    public class RemoveEmployeeTest
    {
        [Fact]
        public async Task RemoveEmployee_Success_ReturnsValidResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<EmployeeServices>>();
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            var mockId = "goijnfeioug3982589njgfd";

            var mockEmployee = new Employee
            {
                Email = "test@mail.com", 
                Alias = "TestMock1"
            };

            employeeRepositoryMock.Setup
                (repo => repo.GetEmployee(mockId)).ReturnsAsync(mockEmployee);

            employeeRepositoryMock.Setup
                (repo => repo.Inactivate(mockEmployee)).ReturnsAsync(true);

            var empService = new EmployeeServices(
                loggerMock.Object,
                employeeRepositoryMock.Object
            );

            // Act
            var result = await empService.RemoveEmployee(mockId);

            // Assert
            Assert.True(result.IsSuccess);
        }


        [Fact]
        public async Task RemoveEmployee_EmployeeIsNull_ReturnsErrorResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<EmployeeServices>>();
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            string mockId = null;

            employeeRepositoryMock.Setup
                (repo => repo.GetEmployee(mockId)).ReturnsAsync((Employee)null);

            var empService = new EmployeeServices(
               loggerMock.Object,
               employeeRepositoryMock.Object
               );

            // Act
            var result = await empService.RemoveEmployee(mockId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.False(result.Data);
            Assert.Equal("Employee could not be found", result.ErrorMessage);
        }


        [Fact]
        public async Task RemoveEmployee_EmployeeCouldNotDeactivate_ReturnsErrorResponse()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<EmployeeServices>>();
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();

            string mockId = "fdgdf00fghd09";

            var mockEmployee = new Employee
            {
                Email = "test@mail.com",
                Alias = "TestMock1",
                IsDeleted = true,
            };

            employeeRepositoryMock.Setup
                (repo => repo.GetEmployee(mockId)).ReturnsAsync(mockEmployee);

            employeeRepositoryMock.Setup
                (repo => repo.Inactivate(mockEmployee)).ReturnsAsync(false);

            var empService = new EmployeeServices(
               loggerMock.Object,
               employeeRepositoryMock.Object
               );

            // Act
            var result = await empService.RemoveEmployee(mockId);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.False(result.Data);
            Assert.Equal("Employee could not be deleted", result.ErrorMessage);
        }


    }
}
