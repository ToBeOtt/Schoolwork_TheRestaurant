using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public static class SeedOrder
    {
        public static void OrderSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = DateTime.Now, OrderStatusId = 1 },
                new Order { Id = 2, OrderDate = DateTime.Now, OrderStatusId = 2 }
            );
        }
    }
}
