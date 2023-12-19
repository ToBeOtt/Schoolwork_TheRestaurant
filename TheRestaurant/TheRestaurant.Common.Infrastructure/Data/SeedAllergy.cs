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
                new Allergy { Id = 1, Name = "Jordnötter" },
                new Allergy { Id = 2, Name = "Skaldjur" },
                new Allergy { Id = 3, Name = "Mjölk" },
                new Allergy { Id = 4, Name = "Ägg" },
                new Allergy { Id = 5, Name = "Fisk" },
                new Allergy { Id = 6, Name = "Nötter" },
                new Allergy { Id = 7, Name = "Vete" },
                new Allergy { Id = 8, Name = "Soja" },
                new Allergy { Id = 9, Name = "Sesamfrö" },
                new Allergy { Id = 10, Name = "Sulfiter" }
            );
        }
    }

}
