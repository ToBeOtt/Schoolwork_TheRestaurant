using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public class ProductSeeds
    {
        private readonly RestaurantDbContext _context;
        public ProductSeeds(RestaurantDbContext context)
        {
            _context = context;
        }

        public byte[] GetImageAsByteArray(string imageName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"..\..\..\..\..\TheRestaurant.Common.Infrastructure\SeedImages\SeedProductImages";
            string imagePath = Path.Combine(basePath, relativePath, imageName);
            imagePath = Path.GetFullPath(imagePath);

            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException($"The file {imagePath} does not exist.");
            }

            return File.ReadAllBytes(imagePath);
        }


        public async Task SeedProducts()
        {
            if (!_context.Products.Any())
            {
                var productData = new List<(string Name, string Description, double Price, bool IsFoodItem, bool IsDeleted, string ImageName, int[] CategoryIds, int[] AllergyIds)>
                {
                    ("Hamburgare med pommes", "Hamburgare med krispiga pommes", 79, true, false, "burger-with-fries.jpg", new int[] {9}, new int[] {7, 9}),
                    ("Kebabpizza", "God kebabpizza med färska grönsaker", 99, true, false, "Kebab-pizza.jpg", new int[] {11}, new int[] {3, 7}),
                    ("Grillad lax", "Grillad lax med dill och citronsås", 129, true, false, "grilled-salmon.jpg", new int[] {7}, new int[] {5}),
                    ("Caesarsallad", "Krispig sallad med kyckling och caesardressing", 89, true, false, "caesar-salad.jpg", new int[] {2}, new int[] {}),
                    ("Mozzarella Sticks", "Friterade mozzarella sticks med dipp", 49, true, false, "mozzarella-sticks.jpg", new int[] {1}, new int[] {3, 7}),
                    ("Chokladfondant", "Varm chokladkaka med flytande kärna", 69, true, false, "chocolate-fondant.jpg", new int[] {16}, new int[] {1, 3, 7}),
                    ("Vegetarisk curry", "Kryddig vegetarisk curry med ris", 109, true, false, "vegetarian-curry.jpg", new int[] {8, 12}, new int[] {}),
                    ("Tom Yum Soppa", "Syrlig thailändsk soppa med räkor", 119, true, false, "tom-yum-soup.jpg", new int[] {3}, new int[] {2, 5}),
                    ("Lammkotletter", "Grillade lammkotletter med rosmarin", 149, true, false, "lamb-chops.jpg", new int[] {6}, new int[] {}),
                    ("Blåbärspaj", "Blåbärspaj med vaniljsås", 59, true, false, "blueberry-pie.jpg", new int[] {16}, new int[] {1, 7}),

                    ("Cola", "Klassisk kolsyrad läsk med unik smak", 20, true, false, "cola.jpg", new int[] {14}, new int[] {}),
                    ("Fanta", "Fruktig apelsinläsk med kolsyra", 20, true, false, "fanta.jpg", new int[] {14}, new int[] {}),
                    ("Lokalt mikrobryggeri öl", "Öl från lokala mikrobryggerier", 40, true, false, "craft-beer.jpg", new int[] {15}, new int[] {1}),
                    ("Husets röda vin", "Välbalanserat rödvin från husets urval", 60, true, false, "house-red-wine.jpg", new int[] {15}, new int[] {}),
                    // Add more products here (merch)
            };

                foreach (var data in productData)
                {
                    var imageBytes = GetImageAsByteArray(data.ImageName);

                    var product = new Product
                    {
                        Name = data.Name,
                        Description = data.Description,
                        Price = data.Price,
                        IsFoodItem = data.IsFoodItem,
                        IsDeleted = data.IsDeleted,
                        MenuPhoto = imageBytes // Set the byte data

                    };

                    await _context.Products.AddAsync(product);

                    foreach (var categoryId in data.CategoryIds)
                    {
                        _context.ProductCategories.Add(new ProductCategory
                        {
                            Product = product,
                            CategoryId = categoryId
                        });
                    }
                    foreach (var allergyId in data.AllergyIds)
                    {
                        _context.ProductAllergies.Add(new ProductAllergy
                        {
                            Product = product,
                            AllergyId = allergyId
                        });
                    }
                }

               

                await _context.SaveChangesAsync();
            }

        }



    }
}
