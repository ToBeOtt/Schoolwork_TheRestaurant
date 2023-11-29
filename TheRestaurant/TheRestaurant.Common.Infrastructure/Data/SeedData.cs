using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Menu;
using TheRestaurant.Domain.Entities.OrderEntities;

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

    }
}
