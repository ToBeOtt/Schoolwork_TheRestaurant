using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public class ProductImageUpdater
    {
        private readonly RestaurantDbContext _context;

        public ProductImageUpdater(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task AddImagesToProductsAsync()
        {
            var productsWithoutImages = await _context.Products.Where(p => p.MenuPhoto == null).ToListAsync();

            foreach (var product in productsWithoutImages)
            {
                string imageName = GetImageNameForProduct(product.Name);
                product.MenuPhoto = GetImageAsByteArray(imageName);
            }
            await _context.SaveChangesAsync();
        }

        public byte[] GetImageAsByteArray(string imageName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"..\..\..\..\..\TheRestaurant.Common.Infrastructure\SeedImages\SeedProductImages";
            string imagePath = Path.Combine(basePath, relativePath, imageName);
            imagePath = Path.GetFullPath(imagePath);

            // Debugging: Print the imagePath to understand where it's pointing
            Console.WriteLine("Resolved Image Path: " + imagePath);

            if (!File.Exists(imagePath))
            {
                throw new FileNotFoundException($"The file {imagePath} does not exist.");
            }

            return File.ReadAllBytes(imagePath);
        }

        private string GetImageNameForProduct(string productName)
        {
            // Convert the product name to a lowercase string with hyphens instead of spaces
            return productName.ToLower().Replace(" ", "-") + ".jpg";
        }

    }
}
