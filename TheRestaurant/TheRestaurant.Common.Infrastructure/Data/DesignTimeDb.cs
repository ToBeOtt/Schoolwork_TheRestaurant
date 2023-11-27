using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Common.Infrastructure.Data;

namespace TheRestaurant.Common.Infrastructure.Data
{
public class RestaurantDbContextFactory : IDesignTimeDbContextFactory<RestaurantDbContext>
{
    public RestaurantDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RestaurantDbContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TheRestaurantDB;User Id=DESKTOP-TR1U524\\BlasterBen;");

        return new RestaurantDbContext(optionsBuilder.Options);
    }
}

}
