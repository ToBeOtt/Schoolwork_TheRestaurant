using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public static class OrderSeed2
    {

        public static void SeedOrder2(this ModelBuilder modelBuilder)
        {
            //TODO 3 pending orders, 3 active orders, 3 orders spread out on 3 different days.
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

            // Seed Order
            var pendingOrders = new List<Order>
            {
                new Order { Id = 3, OrderDate = DateTime.Now, OrderStatusId = 1 },
                new Order { Id = 4, OrderDate = DateTime.Now, OrderStatusId = 1 },
                new Order { Id = 5, OrderDate = DateTime.Now, OrderStatusId = 1 }
            };


            var activeOrders = new List<Order>
            {
                new Order { Id = 6, OrderDate = DateTime.Now.AddDays(-1), OrderStatusId = 2 },
                new Order { Id = 7, OrderDate = DateTime.Now.AddDays(-1), OrderStatusId = 2 },
                new Order { Id = 8, OrderDate = DateTime.Now.AddDays(-1), OrderStatusId = 2 }
            };

            var spreadOrders = new List<Order>
            {
                new Order { Id = 9, OrderDate = DateTime.Now.AddDays(-2), OrderStatusId = 1 },
                new Order { Id = 10, OrderDate = DateTime.Now.AddDays(-3), OrderStatusId = 2 },
                new Order { Id = 11, OrderDate = DateTime.Now.AddDays(-4), OrderStatusId = 1 }
            };

            modelBuilder.Entity<Order>().HasData(pendingOrders, activeOrders, spreadOrders);




            var orderRowsForPendingOrders = new List<OrderRow>
            {
                new OrderRow { Id = 16, OrderId = 3, ProductId = hamburgerProductId },
                new OrderRow { Id = 17, OrderId = 3, ProductId = salmonProductId },
                new OrderRow { Id = 18, OrderId = 4, ProductId = kebabProductId },
                new OrderRow { Id = 19, OrderId = 4, ProductId = mozzarellaProductId },
                new OrderRow { Id = 20, OrderId = 5, ProductId = caesarProductId }
            };

            var orderRowsForActiveOrders = new List<OrderRow>
            {
                new OrderRow { Id = 21, OrderId = 6, ProductId = chocolateProductId },
                new OrderRow { Id = 22, OrderId = 6, ProductId = veggocurryProductId },
                new OrderRow { Id = 23, OrderId = 7, ProductId = tomyumsoupProductId },
                new OrderRow { Id = 24, OrderId = 7, ProductId = lambchopsProductId },
                new OrderRow { Id = 25, OrderId = 8, ProductId = blueberrypieProductId }
            };

            var orderRowsForSpreadOrders = new List<OrderRow>
            {
                new OrderRow { Id = 26, OrderId = 9, ProductId = hamburgerProductId },
                new OrderRow { Id = 27, OrderId = 10, ProductId = salmonProductId },
                new OrderRow { Id = 28, OrderId = 11, ProductId = kebabProductId }
            };

            modelBuilder.Entity<OrderRow>().HasData(orderRowsForPendingOrders.ToArray());
            modelBuilder.Entity<OrderRow>().HasData(orderRowsForActiveOrders.ToArray());
            modelBuilder.Entity<OrderRow>().HasData(orderRowsForSpreadOrders.ToArray());
        }
    }
}
