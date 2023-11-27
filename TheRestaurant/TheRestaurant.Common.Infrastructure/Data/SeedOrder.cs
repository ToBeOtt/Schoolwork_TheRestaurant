using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.OrderEntities;

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
                OrderStatus = orderStatus
            };
            modelBuilder.Entity<Order>().HasData(order);
        }



        // Add similar methods for EmployeeOrder, OrderRow, Item, MenuItemAllergy, and MenuItemCategory
    }
}
