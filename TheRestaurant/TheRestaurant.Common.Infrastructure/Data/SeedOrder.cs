using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public class OrderSeed
    {
      
        public static void SeedOrder(ModelBuilder modelBuilder)
        {
            var orderStatus = new OrderStatus { Id = 1, Status = "Processing" };
            modelBuilder.Entity<OrderStatus>().HasData(orderStatus);

            var order = new Order
            {
                Id = 1,
                OrderDate = DateTime.Now,
                //OrderStatus = orderStatus
            };
            modelBuilder.Entity<Order>().HasData(order);
        }



        // Add similar methods for EmployeeOrder, OrderRow, Item, MenuItemAllergy, and MenuItemCategory
    }
}
