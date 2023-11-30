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
            optionsBuilder.UseSqlServer("Server=(local);Database=TheRestaurantDB;Integrated Security=True;TrustServerCertificate=True;");

        return new RestaurantDbContext(optionsBuilder.Options);
    }
}

}
