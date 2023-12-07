using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public static class OrderSeed2
    {

        public static void SeedOrder2(this ModelBuilder modelBuilder)
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

            var orderStatus = 1;
            var processingStatus = 2;
            var completedStatus = 3;
            var cancelledStatus = 4;
            var activeStatus = 5;

            var pendingOrders = new List<Order>
            {
                new Order
                {
                    Id = 31,
                    OrderDate = DateTime.Now,
                    OrderStatusId = orderStatus
                },
                new Order
                {
                    Id = 4,
                    OrderDate = DateTime.Now,
                    OrderStatusId = orderStatus
                },
                new Order
                {
                    Id = 5,
                    OrderDate = DateTime.Now,
                    OrderStatusId = orderStatus }
            };

            var spreadOrders = new List<Order>
            {
                new Order
                {
                    Id = 34,
                    OrderDate = DateTime.Now.AddDays(-2),
                    OrderStatusId = orderStatus
                },
                new Order
                {
                    Id = 10,
                    OrderDate = DateTime.Now.AddDays(-3),
                    OrderStatusId = completedStatus
                },
                new Order
                {
                    Id = 11,
                    OrderDate = DateTime.Now.AddDays(-4),
                    OrderStatusId = cancelledStatus
                }
            };
            var activeOrders = new Order
            {
                Id = 6,
                OrderDate = DateTime.Now.AddDays(-1),
                OrderStatusId = activeStatus
            };
            var activeOrders2 = new Order
            {
                Id = 32,
                OrderDate = DateTime.Now.AddDays(-1),
                OrderStatusId = processingStatus
            };
            var activeOrders3 = new Order
            {
                Id = 33,
                OrderDate = DateTime.Now.AddDays(-1),
                OrderStatusId = activeStatus
            };

            modelBuilder.Entity<Order>().HasData(activeOrders2, activeOrders, activeOrders3, spreadOrders, pendingOrders);

            var orderRowsForPendingOrders = new List<OrderRow>
            {
                new OrderRow { Id = 16, OrderId = 31, ProductId = hamburgerProductId },
                new OrderRow { Id = 17, OrderId = 31, ProductId = salmonProductId },
                new OrderRow { Id = 18, OrderId = 4, ProductId = kebabProductId },
                new OrderRow { Id = 19, OrderId = 4, ProductId = mozzarellaProductId },
                new OrderRow { Id = 20, OrderId = 5, ProductId = caesarProductId }
            };

            var orderRowsForActiveOrders = new List<OrderRow>
            {
                new OrderRow { Id = 21, OrderId = 6, ProductId = chocolateProductId },
                new OrderRow { Id = 22, OrderId = 6, ProductId = veggocurryProductId },
                new OrderRow { Id = 23, OrderId = 32, ProductId = tomyumsoupProductId },
                new OrderRow { Id = 24, OrderId = 32, ProductId = lambchopsProductId },
                new OrderRow { Id = 25, OrderId = 33, ProductId = blueberrypieProductId }
            };

            var orderRowsForSpreadOrders = new List<OrderRow>
            {
                new OrderRow { Id = 26, OrderId = 34, ProductId = hamburgerProductId },
                new OrderRow { Id = 27, OrderId = 10, ProductId = salmonProductId },
                new OrderRow { Id = 28, OrderId = 11, ProductId = kebabProductId }
            };


            modelBuilder.Entity<OrderRow>().HasData(orderRowsForPendingOrders.ToArray());
            modelBuilder.Entity<OrderRow>().HasData(orderRowsForActiveOrders.ToArray());
            modelBuilder.Entity<OrderRow>().HasData(orderRowsForSpreadOrders.ToArray());
        }
    }
}
