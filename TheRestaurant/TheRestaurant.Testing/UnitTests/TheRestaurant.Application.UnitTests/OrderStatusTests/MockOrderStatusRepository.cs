using Moq;
using TheRestaurant.Application.Interfaces.ICategory;
using TheRestaurant.Application.Interfaces.IOrderStatus;
using TheRestaurant.Domain.Entities.Menu;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Testing.UnitTests.TheRestaurant.Application.UnitTests.OrderStatusTests
{
    public static class MockOrderStatusRepository
    {
        public static Mock<IOrderStatusRepository> GetMock()
        {
            var orderStatusList = new List<OrderStatus>()
            {
                 new OrderStatus { Id = 1, Status = "Pending", IsDeleted = false },
                new OrderStatus { Id = 2, Status = "Processing", IsDeleted = false },
                new OrderStatus { Id = 3, Status = "Delivered", IsDeleted = false },
                new OrderStatus { Id = 4, Status = "Cancelled", IsDeleted = false }
            };


            var mockRepo = new Mock<IOrderStatusRepository>();

            // GetAllAsync
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(orderStatusList);


            // GetByIdAsync
            mockRepo.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var result = from c in orderStatusList where c.Id == id select c;
                var category = new OrderStatus
                {
                    Id = id,
                    Status = result.First().Status,
                    IsDeleted = result.First().IsDeleted
                };

                return category;
            });


            // UpdateAsync
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<OrderStatus>())).ReturnsAsync((OrderStatus orderStatus) =>
            {
                return orderStatus;
            });


            return mockRepo;
        }
    }
}
