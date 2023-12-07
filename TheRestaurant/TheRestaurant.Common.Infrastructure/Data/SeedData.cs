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
                new Category { Id = 1, Name = "Appetizers", IsDeleted = false },
                new Category { Id = 2, Name = "Salads", IsDeleted = false },
                new Category { Id = 3, Name = "Soups", IsDeleted = true },
                new Category { Id = 4, Name = "Pasta", IsDeleted = false },
                new Category { Id = 5, Name = "Steak", IsDeleted = false },
                new Category { Id = 6, Name = "Lamb", IsDeleted = true },
                new Category { Id = 7, Name = "Seafood", IsDeleted = false },
                new Category { Id = 8, Name = "Vegetarian", IsDeleted = false },
                new Category { Id = 9, Name = "Burgers", IsDeleted = false },
                new Category { Id = 10, Name = "Sandwiches", IsDeleted = false },
                new Category { Id = 11, Name = "Pizza", IsDeleted = false },
                new Category { Id = 12, Name = "Rice", IsDeleted = false },
                new Category { Id = 13, Name = "Sushi", IsDeleted = true },
                new Category { Id = 14, Name = "Non Alcoholic Beverages", IsDeleted = false },
                new Category { Id = 15, Name = "Alcoholic Beverages", IsDeleted = true },
                new Category { Id = 16, Name = "Desserts", IsDeleted = false },
                new Category { Id = 17, Name = "Poultry", IsDeleted = false }

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
