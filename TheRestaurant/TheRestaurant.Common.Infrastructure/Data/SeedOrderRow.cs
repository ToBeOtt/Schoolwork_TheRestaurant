using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public static class SeedOrderRow
    {
        public static void OrderRowSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderRow>().HasData(
                new OrderRow { Id = 1, OrderId = new Order() },
                new OrderRow { Id = 2, OrderId = new Order() }
            );
        }
    }
}
