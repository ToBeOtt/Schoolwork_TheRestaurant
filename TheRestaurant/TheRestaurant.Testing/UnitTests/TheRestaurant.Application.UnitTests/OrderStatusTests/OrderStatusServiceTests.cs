using Moq;
using TheRestaurant.Application.Interfaces.IOrderStatus;
using TheRestaurant.Application.Services;
using TheRestaurant.Contracts.DTOs;
using TheRestaurant.Testing.UnitTests.TheRestaurant.Application.UnitTests.CategoryTests;

namespace TheRestaurant.Testing.UnitTests.TheRestaurant.Application.UnitTests.OrderStatusTests
{
    public class OrderStatusServiceTests
    {
        readonly Mock<IOrderStatusRepository> _mockRepository;
        public OrderStatusServiceTests()
        {
            _mockRepository = MockOrderStatusRepository.GetMock();
        }


        [Fact]
        public async Task GetAllAsyncTest()
        {
            // Arrange
            var orderStatusService = new OrderStatusService(_mockRepository.Object);

            // Act
            var result = await orderStatusService.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);

        }


        [Fact]
        public async Task GetAsyncTest()
        {
            // Arrange
            var orderStatusService = new OrderStatusService(_mockRepository.Object);

            // Act
            var result = await orderStatusService.GetAsync(3);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Delivered", result.Status);
            Assert.Equal(3, result.Id);

        }


        [Fact]
        public async Task UpdateAsyncTest()
        {
            // Arrange
            var orderStatusService = new OrderStatusService(_mockRepository.Object);

            var orderStatus = new OrderStatusDto { Id = 1, Status = "Active", IsDeleted = true };

            //// Act
            var updated = await orderStatusService.UpdateAsync(orderStatus);

            // Assert
            Assert.NotNull(updated);
            Assert.Equal(true, updated);

        }
    }
}
