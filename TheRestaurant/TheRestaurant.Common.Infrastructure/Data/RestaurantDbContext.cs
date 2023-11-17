using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheRestaurant.Domain.Entities.Authentication;

namespace Common.Infrastructure.Data
{
    public class RestaurantDbContext : IdentityDbContext<AppUser>
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; } = null!;
    }
}
