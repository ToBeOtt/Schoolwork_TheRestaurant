using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Menu;

public static class ProductSeeds
{
    //private readonly RestaurantDbContext _context;
    //public ProductSeeds(RestaurantDbContext context)
    //{
    //    _context = context;
    //}

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
            new Product { Id = 14, Name = "Husets röda vin", Description = "Välbalanserat rödvin från husets urval", Price = 60, IsFoodItem = false, IsDeleted = false }
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
            new ProductCategory { Id = 15, ProductId = 14, CategoryId = 15 }
        // ... and so on
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

    //public byte[] GetImageAsByteArray(string imageName)
    //{
    //    string basePath = AppDomain.CurrentDomain.BaseDirectory;
    //    string relativePath = @"..\..\..\..\..\TheRestaurant.Common.Infrastructure\SeedImages\SeedProductImages";
    //    string imagePath = Path.Combine(basePath, relativePath, imageName);
    //    imagePath = Path.GetFullPath(imagePath);

    //    if (!File.Exists(imagePath))
    //    {
    //        throw new FileNotFoundException($"The file {imagePath} does not exist.");
    //    }

    //    return File.ReadAllBytes(imagePath);
    //}


    //public async Task SeedProducts()
    //{
    //    if (!_context.Products.Any())
    //    {
    //        var productData = new List<(string Name, string Description, double Price, bool IsFoodItem, bool IsDeleted, string ImageName, int[] CategoryIds, int[] AllergyIds)>
    //        {
    //            ("Hamburgare med pommes", "Hamburgare med krispiga pommes", 79, true, false, "burger-with-fries.jpg", new int[] {9}, new int[] {7, 9}),
    //            ("Kebabpizza", "God kebabpizza med färska grönsaker", 99, true, false, "Kebab-pizza.jpg", new int[] {11}, new int[] {3, 7}),
    //            ("Grillad lax", "Grillad lax med dill och citronsås", 129, true, false, "grilled-salmon.jpg", new int[] {7}, new int[] {5}),
    //            ("Caesarsallad", "Krispig sallad med kyckling och caesardressing", 89, true, false, "caesar-salad.jpg", new int[] {2}, new int[] {}),
    //            ("Mozzarella Sticks", "Friterade mozzarella sticks med dipp", 49, true, false, "mozzarella-sticks.jpg", new int[] {1}, new int[] {3, 7}),
    //            ("Chokladfondant", "Varm chokladkaka med flytande kärna", 69, true, false, "chocolate-fondant.jpg", new int[] {16}, new int[] {1, 3, 7}),
    //            ("Vegetarisk curry", "Kryddig vegetarisk curry med ris", 109, true, false, "vegetarian-curry.jpg", new int[] {8, 12}, new int[] {}),
    //            ("Tom Yum Soppa", "Syrlig thailändsk soppa med räkor", 119, true, false, "tom-yum-soup.jpg", new int[] {3}, new int[] {2, 5}),
    //            ("Lammkotletter", "Grillade lammkotletter med rosmarin", 149, true, false, "lamb-chops.jpg", new int[] {6}, new int[] {}),
    //            ("Blåbärspaj", "Blåbärspaj med vaniljsås", 59, true, false, "blueberry-pie.jpg", new int[] {16}, new int[] {1, 7}),

    //            ("Cola", "Klassisk kolsyrad läsk med unik smak", 20, true, false, "cola.jpg", new int[] {14}, new int[] {}),
    //            ("Fanta", "Fruktig apelsinläsk med kolsyra", 20, true, false, "fanta.jpg", new int[] {14}, new int[] {}),
    //            ("Lokalt mikrobryggeri öl", "Öl från lokala mikrobryggerier", 40, true, false, "craft-beer.jpg", new int[] {15}, new int[] {1}),
    //            ("Husets röda vin", "Välbalanserat rödvin från husets urval", 60, true, false, "house-red-wine.jpg", new int[] {15}, new int[] {}),
    //            // Add more products here (merch)
    //    };

    //        foreach (var data in productData)
    //        {
    //            var imageBytes = GetImageAsByteArray(data.ImageName);

    //            var product = new Product
    //            {
    //                Name = data.Name,
    //                Description = data.Description,
    //                Price = data.Price,
    //                IsFoodItem = data.IsFoodItem,
    //                IsDeleted = data.IsDeleted,
    //                MenuPhoto = imageBytes // Set the byte data

    //            };

    //            await _context.Products.AddAsync(product);

    //            foreach (var categoryId in data.CategoryIds)
    //            {
    //                _context.ProductCategories.Add(new ProductCategory
    //                {
    //                    Product = product,
    //                    CategoryId = categoryId
    //                });
    //            }
    //            foreach (var allergyId in data.AllergyIds)
    //            {
    //                _context.ProductAllergies.Add(new ProductAllergy
    //                {
    //                    Product = product,
    //                    AllergyId = allergyId
    //                });
    //            }
    //        }



    //        await _context.SaveChangesAsync();
    //    }

    //}



}