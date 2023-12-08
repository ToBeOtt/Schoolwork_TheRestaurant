using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Menu;

public static class ProductSeeds
{
    public static void SeedProducts(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Hamburgare med pommes", Description = "Hamburgare med krispiga pommes", Price = 79, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 2, Name = "Kebabpizza", Description = "God kebabpizza med färska grönsaker", Price = 99, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 3, Name = "Grillad lax", Description = "Grillad lax med dill och citronsås", Price = 129, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 4, Name = "Caesarsallad", Description = "Krispig sallad med kyckling och caesardressing", Price = 89, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 5, Name = "Mozzarella Sticks", Description = "Friterade mozzarella sticks med dipp", Price = 49, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 6, Name = "Chokladfondant", Description = "Varm chokladkaka med flytande kärna", Price = 69, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 7, Name = "Vegetarisk curry", Description = "Kryddig vegetarisk curry med ris", Price = 109, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 8, Name = "Tom Yum Soppa", Description = "Syrlig thailändsk soppa med räkor", Price = 119, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 9, Name = "Lammkotletter", Description = "Grillade lammkotletter med rosmarin", Price = 149, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 10, Name = "Blåbärspaj", Description = "Blåbärspaj med vaniljsås", Price = 59, IsFoodItem = true, IsDeleted = false },
            new Product { Id = 11, Name = "Cola", Description = "Klassisk kolsyrad läsk med unik smak", Price = 20, IsFoodItem = false, IsDeleted = false },
            new Product { Id = 12, Name = "Fanta", Description = "Fruktig apelsinläsk med kolsyra", Price = 20, IsFoodItem = false, IsDeleted = false },
            new Product { Id = 13, Name = "Lokalt mikrobryggeri öl", Description = "Öl från lokala mikrobryggerier", Price = 40, IsFoodItem = false, IsDeleted = false },
            new Product { Id = 14, Name = "Husets röda vin", Description = "Välbalanserat rödvin från husets urval", Price = 60, IsFoodItem = false, IsDeleted = false },
            new Product { Id = 15, Name = "Kaffe mugg", Description = "Isolerad resemugg", Price = 120, IsFoodItem = false, IsDeleted = false },
            new Product { Id = 16, Name ="Kokbok", Description = "Kokbok som innehåller alla våra goda recept", Price = 99, IsFoodItem = false, IsDeleted = false},
            new Product { Id = 17, Name = "Såspanna", Description = "Högkvalitativ såspanna perfekt för alla typer av såser", Price = 450, IsFoodItem = false, IsDeleted = false }
        );


        modelBuilder.Entity<ProductCategory>().HasData(
            // Categories for "Hamburgare med pommes"
            new ProductCategory { Id = 1, ProductId = 1, CategoryId = 9 },

            // Categories for "Kebabpizza"
            new ProductCategory { Id = 2, ProductId = 2, CategoryId = 11 },

            // Categories for "Grillad lax"
            new ProductCategory { Id = 3, ProductId = 3, CategoryId = 7 },

            // Categories for "Caesarsallad"
            new ProductCategory { Id = 4, ProductId = 4, CategoryId = 2 },

            // Categories for "Mozzarella Sticks"
            new ProductCategory { Id = 5, ProductId = 5, CategoryId = 1 },

            // Categories for "Chokladfondant"
            new ProductCategory { Id = 6, ProductId = 6, CategoryId = 16 },

            // Categories for "Vegetarisk curry"
            new ProductCategory { Id = 7, ProductId = 7, CategoryId = 8 },
            new ProductCategory { Id = 8, ProductId = 7, CategoryId = 12 },

            // Categories for "Tom Yum Soppa"
            new ProductCategory { Id = 9, ProductId = 8, CategoryId = 3 },

            // Categories for "Lammkotletter"
            new ProductCategory { Id = 10, ProductId = 9, CategoryId = 6 },

            // Categories for "Blåbärspaj"
            new ProductCategory { Id = 11, ProductId = 10, CategoryId = 16 },

            // Categories for drinks
            new ProductCategory { Id = 12, ProductId = 11, CategoryId = 14 },
            new ProductCategory { Id = 13, ProductId = 12, CategoryId = 14 },
            new ProductCategory { Id = 14, ProductId = 13, CategoryId = 15 },
            new ProductCategory { Id = 15, ProductId = 14, CategoryId = 15 },
            
            // Categories for merch
            new ProductCategory { Id = 16, ProductId = 15, CategoryId=18},
            new ProductCategory { Id = 17, ProductId = 16, CategoryId=18},
            new ProductCategory { Id = 18, ProductId = 17, CategoryId=18}
        );

        modelBuilder.Entity<ProductAllergy>().HasData(
            // Allergies for "Hamburgare med pommes"
            new ProductAllergy { Id = 1, ProductId = 1, AllergyId = 7 },
            new ProductAllergy { Id = 2, ProductId = 1, AllergyId = 9 },

            // Allergies for "Kebabpizza"
            new ProductAllergy { Id = 3, ProductId = 2, AllergyId = 3 },
            new ProductAllergy { Id = 4, ProductId = 2, AllergyId = 7 },

            // Allergies for "Grillad lax"
            new ProductAllergy { Id = 5, ProductId = 3, AllergyId = 5 },

            // Allergies for "Mozzarella Sticks"
            new ProductAllergy { Id = 6, ProductId = 5, AllergyId = 3 },
            new ProductAllergy { Id = 7, ProductId = 5, AllergyId = 7 },

            // Allergies for "Chokladfondant"
            new ProductAllergy { Id = 8, ProductId = 6, AllergyId = 1 },
            new ProductAllergy { Id = 9, ProductId = 6, AllergyId = 3 },
            new ProductAllergy { Id = 10, ProductId = 6, AllergyId = 7 },

            // Allergies for "Tom Yum Soppa"
            new ProductAllergy { Id = 11, ProductId = 8, AllergyId = 2 },
            new ProductAllergy { Id = 12, ProductId = 8, AllergyId = 5 },

            // Allergies for "Blåbärspaj"
            new ProductAllergy { Id = 13, ProductId = 10, AllergyId = 1 },
            new ProductAllergy { Id = 14, ProductId = 10, AllergyId = 7 },

            // Allergies for "Lokalt mikrobryggeri öl"
            new ProductAllergy { Id = 15, ProductId = 13, AllergyId = 1 }
        );
    }
}