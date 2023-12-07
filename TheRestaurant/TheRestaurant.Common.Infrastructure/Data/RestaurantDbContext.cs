using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using TheRestaurant.Common.Infrastructure.Data;
using TheRestaurant.Domain.Entities.Authentication;
using TheRestaurant.Domain.Entities.Menu;
using TheRestaurant.Domain.Entities.Orders;

namespace Common.Infrastructure.Data
{
    public class RestaurantDbContext : IdentityDbContext<Employee>
    {
        public RestaurantDbContext
            (DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;

        public DbSet<ProductAllergy> ProductAllergies { get; set; } = null!;
        public DbSet<Allergy> Allergies { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderRow> OrderRows { get; set; } = null!;

        public DbSet<OrderStatus> OrderStatus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.ApplyConfiguration(new OrderConfiguration());
            builder.AllergySeed();
            builder.CategorySeed();
            //OrderSeed.SeedOrder(builder);
            builder.SeedOrder();
            builder.SeedOrder2();
            builder.OrderStatusSeed();
            //builder.OrderRowSeed();


            base.OnModelCreating(builder);

        }

    }

}
