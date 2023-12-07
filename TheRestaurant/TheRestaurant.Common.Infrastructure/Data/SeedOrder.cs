using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public class OrderSeed
    {

        public static void SeedOrder(ModelBuilder modelBuilder)
        {
            int hamburgerProductId = 1;
            int kebabProductId = 2;
            int salmonProductId = 3;
            int caesarProductId = 4;
            int mozzarellaProductId = 5;
            int chocolateProductId = 6;
            int veggocurryProductId = 7;
            int tomyumsoupProductId = 8;
            int lambchopsProductId = 9;
            int blueberrypieProductId = 10;

            var orderStatus = new OrderStatus { Id = 1, Status = "Pending" };
            var completedStatus = new OrderStatus { Id = 3, Status = "Delivered" };
            modelBuilder.Entity<OrderStatus>().HasData(orderStatus);

            // Seed Order
            var order1 = new Order
            {
                Id = 1,
                OrderDate = DateTime.Now,
                //OrderStatus = orderStatus
            };

            var order2 = new Order
            {
                Id = 2,
                OrderDate = DateTime.Now.AddDays(-1),
                OrderStatus = completedStatus
            };

            modelBuilder.Entity<Order>().HasData(order1, order2);

            var orderRowsForOrder1 = new List<OrderRow>
            {
                new OrderRow { Id = 1, OrderId = 1, ProductId = hamburgerProductId },
                new OrderRow { Id = 2, OrderId = 1, ProductId = kebabProductId },
                new OrderRow { Id = 3, OrderId = 1, ProductId = salmonProductId },
                new OrderRow { Id = 4, OrderId = 1, ProductId = caesarProductId },
                new OrderRow { Id = 5, OrderId = 1, ProductId = mozzarellaProductId }
            };

            var orderRowsForOrder2 = new List<OrderRow>
            {
                new OrderRow { Id = 6, OrderId = 2, ProductId = chocolateProductId },
                new OrderRow { Id = 7, OrderId = 2, ProductId = veggocurryProductId },
                new OrderRow { Id = 8, OrderId = 2, ProductId = tomyumsoupProductId },
                new OrderRow { Id = 9, OrderId = 2, ProductId = lambchopsProductId },
                new OrderRow { Id = 10, OrderId = 2, ProductId = blueberrypieProductId }
            };

            modelBuilder.Entity<OrderRow>().HasData(orderRowsForOrder1.ToArray());
            modelBuilder.Entity<OrderRow>().HasData(orderRowsForOrder2.ToArray());
        }
    }
}
