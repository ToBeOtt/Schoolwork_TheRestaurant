using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public static class SeedOrderStatus
    {
        public static void OrderStatusSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Status = "Pending" },
                new OrderStatus { Id = 2, Status = "Processing" },
                new OrderStatus { Id = 3, Status = "Delivered" },
                new OrderStatus { Id = 4, Status = "Cancelled" }
               
            );
        }
    }
}
