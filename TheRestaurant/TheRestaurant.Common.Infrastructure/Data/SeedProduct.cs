using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Menu;
using TheRestaurant.Domain.Entities.Orders;

public static class ProductSeeds
{
    public static void SeedProducts(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<VAT>().HasData(
            new VAT { Id = 1, Name = "Mat", Adjustment = 1.12 },
            new VAT { Id = 2, Name = "Böcker", Adjustment = 1.06 },
            new VAT { Id = 3, Name = "Aklohol", Adjustment = 1.25 },
            new VAT { Id = 4, Name = "Varor/Kläder", Adjustment = 1.25 }

        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Hamburgare med pommes", Description = "Hamburgare med krispiga pommes", PriceBeforeVAT = 88.39, Price = Math.Round(88.39 * 1.12, 2), IsFoodItem = true, IsDeleted = false, VATId = 1 },
            new Product { Id = 2, Name = "Kebabpizza", Description = "God kebabpizza med färska grönsaker", PriceBeforeVAT = 106.25, Price = Math.Round(106.25 * 1.12, 2), IsFoodItem = true, IsDeleted = false, VATId = 1 },
            new Product { Id = 3, Name = "Grillad lax", Description = "Grillad lax med dill och citronsås", PriceBeforeVAT = 124.11, Price = Math.Round(124.11 * 1.12, 2), IsFoodItem = true, IsDeleted = false, VATId = 1 },
            new Product { Id = 4, Name = "Caesarsallad", Description = "Krispig sallad med kyckling och caesardressing", PriceBeforeVAT = 88.39, Price = Math.Round(88.39 * 1.12, 2), IsFoodItem = true, IsDeleted = false, VATId = 1 },
            new Product { Id = 5, Name = "Mozzarella Sticks", Description = "Friterade mozzarella sticks med dipp", PriceBeforeVAT = 52.68, Price = Math.Round(52.68 * 1.12, 2), IsFoodItem = true, IsDeleted = false, VATId = 1 },
            new Product { Id = 6, Name = "Chokladfondant", Description = "Varm chokladkaka med flytande kärna", PriceBeforeVAT = 70.54, Price = Math.Round(70.54 * 1.12, 2), IsFoodItem = true, IsDeleted = false , VATId = 1 },
            new Product { Id = 7, Name = "Vegetarisk curry", Description = "Kryddig vegetarisk curry med ris", PriceBeforeVAT = 115.18, Price = Math.Round(115.18 * 1.12, 2), IsFoodItem = true, IsDeleted = false, VATId = 1 },
            new Product { Id = 8, Name = "Tom Yum Soppa", Description = "Syrlig thailändsk soppa med räkor", PriceBeforeVAT = 124.11, Price = Math.Round(124.11 * 1.12, 2), IsFoodItem = true, IsDeleted = false, VATId = 1 },
            new Product { Id = 9, Name = "Lammkotletter", Description = "Grillade lammkotletter med rosmarin", PriceBeforeVAT = 150.89, Price = Math.Round(150.89 * 1.12, 2), IsFoodItem = true, IsDeleted = false, VATId = 1 },
            new Product { Id = 10, Name = "Blåbärspaj", Description = "Blåbärspaj med vaniljsås", PriceBeforeVAT = 61.61, Price = Math.Round(61.61 * 1.12, 2), IsFoodItem = true, IsDeleted = false, VATId = 1 },
            new Product { Id = 11, Name = "Cola", Description = "Klassisk kolsyrad läsk med unik smak", PriceBeforeVAT = 22.32, Price = Math.Round(22.32 * 1.12, 2), IsFoodItem = false, IsDeleted = false, VATId = 1 },
            new Product { Id = 12, Name = "Fanta", Description = "Fruktig apelsinläsk med kolsyra", PriceBeforeVAT = 22.32, Price = Math.Round(22.32 * 1.12, 2), IsFoodItem = false, IsDeleted = false , VATId = 1 },
            new Product { Id = 13, Name = "Lokalt mikrobryggeri öl", Description = "Öl från lokala mikrobryggerier", PriceBeforeVAT = 39.2, Price = Math.Round(39.2 * 1.25, 2), IsFoodItem = false, IsDeleted = false, VATId = 3 },
            new Product { Id = 14, Name = "Husets röda vin", Description = "Välbalanserat rödvin från husets urval", PriceBeforeVAT = 39.2, Price = Math.Round(39.2 * 1.25, 2), IsFoodItem = false, IsDeleted = false, VATId = 3 },
            new Product { Id = 15, Name = "Kaffe mugg", Description = "Isolerad resemugg", PriceBeforeVAT = 103.2, Price = Math.Round(103.2 * 1.25, 2), IsFoodItem = false, IsDeleted = false, VATId = 4 },
            new Product { Id = 16, Name ="Kokbok", Description = "Kokbok som innehåller alla våra goda recept", PriceBeforeVAT = 244.34, Price = Math.Round(244.34 * 1.06, 2), IsFoodItem = false, IsDeleted = false, VATId = 2 },
            new Product { Id = 17, Name = "Såspanna", Description = "Högkvalitativ såspanna perfekt för alla typer av såser", PriceBeforeVAT = 359.2, Price = Math.Round(359.2 * 1.25, 2), IsFoodItem = false, IsDeleted = false, VATId = 4 },
            new Product { Id = 18, Name = "Svart T-shirt", Description = "Elegant svart T-shirt i högkvalitativt material", PriceBeforeVAT = 159.2, Price = Math.Round(159.2 * 1.25, 2), IsFoodItem = false, IsDeleted = false, VATId = 4 },
            new Product { Id = 19, Name = "Vit T-shirt", Description = "Klassisk vit T-shirt i mjukt och bekvämt material", PriceBeforeVAT = 159.2, Price = Math.Round(159.2 * 1.25, 2), IsFoodItem = false, IsDeleted = false, VATId = 4 }

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
            new ProductCategory { Id = 18, ProductId = 17, CategoryId=18},
            new ProductCategory { Id = 19, ProductId = 18, CategoryId=20},
            new ProductCategory { Id = 20, ProductId = 19, CategoryId=20}
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