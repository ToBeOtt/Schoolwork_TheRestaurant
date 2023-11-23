using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public static class SeedAllergy
    {
        public static void AllergySeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergy>().HasData(
                new Allergy { Id = 1, Name = "Peanuts" },
                new Allergy { Id = 2, Name = "Shellfish" },
                new Allergy { Id = 3, Name = "Milk" },
                new Allergy { Id = 4, Name = "Eggs" },
                new Allergy { Id = 5, Name = "Fish" },
                new Allergy { Id = 6, Name = "Tree nuts" },
                new Allergy { Id = 7, Name = "Wheat" },
                new Allergy { Id = 8, Name = "Soy" },
                new Allergy { Id = 9, Name = "Sesame" },
                new Allergy { Id = 10, Name = "Sulfites" }
            );
        }
    }

}
