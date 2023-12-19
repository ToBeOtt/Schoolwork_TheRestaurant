using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Menu;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Common.Infrastructure.Data
{
    internal static class SeedData
    {
        //Category Seed
        public static void CategorySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Förrätter", IsDeleted = false },
                new Category { Id = 2, Name = "Sallader", IsDeleted = false },
                new Category { Id = 3, Name = "Soppor", IsDeleted = true },
                new Category { Id = 4, Name = "Pasta", IsDeleted = false },
                new Category { Id = 5, Name = "Biff", IsDeleted = false },
                new Category { Id = 6, Name = "Lamm", IsDeleted = true },
                new Category { Id = 7, Name = "Skaldjur", IsDeleted = false },
                new Category { Id = 8, Name = "Vegetariskt", IsDeleted = false },
                new Category { Id = 9, Name = "Burgare", IsDeleted = false },
                new Category { Id = 10, Name = "Smörgåsar", IsDeleted = false },
                new Category { Id = 11, Name = "Pizza", IsDeleted = false },
                new Category { Id = 12, Name = "Ris", IsDeleted = false },
                new Category { Id = 13, Name = "Sushi", IsDeleted = true },
                new Category { Id = 14, Name = "Alkoholfria drycker", IsDeleted = false },
                new Category { Id = 15, Name = "Alkoholhaltiga drycker", IsDeleted = true },
                new Category { Id = 16, Name = "Desserter", IsDeleted = false },
                new Category { Id = 17, Name = "Fågel", IsDeleted = false },
                new Category { Id = 18, Name = "Merch", IsDeleted = false },
                new Category { Id = 19, Name = "Kokböcker", IsDeleted = false },
                new Category { Id = 20, Name = "T-shirt", IsDeleted = false },
                new Category { Id = 21, Name = "Muggar", IsDeleted = false },
                new Category { Id = 22, Name = "Såspannor", IsDeleted = false }
            );
        }

        //OrderStatus Seed
        public static void OrderStatusSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Status = "Pending", IsDeleted = false },
                new OrderStatus { Id = 2, Status = "Processing", IsDeleted = false },
                new OrderStatus { Id = 3, Status = "Delivered", IsDeleted = false },
                new OrderStatus { Id = 4, Status = "Cancelled", IsDeleted = false },
                new OrderStatus { Id = 5, Status = "Active", IsDeleted = true }

            );
        }

    }
}
