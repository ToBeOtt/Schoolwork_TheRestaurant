using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Common.Infrastructure.Data
{
    internal static class SeedCategories
    {

        public static void CategorySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Appetizers" },
                new Category { Id = 2, Name = "Salads" },
                new Category { Id = 3, Name = "Soups" },
                new Category { Id = 4, Name = "Pasta" },
                new Category { Id = 5, Name = "Steak" },
                new Category { Id = 6, Name = "Lamb" },
                new Category { Id = 7, Name = "Seafood" },
                new Category { Id = 8, Name = "Vegetarian" },
                new Category { Id = 9, Name = "Burgers" },
                new Category { Id = 10, Name = "Sandwiches" },
                new Category { Id = 11, Name = "Pizza" },
                new Category { Id = 12, Name = "Rice" },
                new Category { Id = 13, Name = "Sushi" },
                new Category { Id = 14, Name = "Non Alcoholic Beverages" },
                new Category { Id = 15, Name = "Alcoholic Beverages" },
                new Category { Id = 16, Name = "Desserts" },
                new Category { Id = 17, Name = "Poultry" }

            );
        }
    }
}
