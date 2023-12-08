using Authentication;
using Common.Infrastructure;
using TheRestaurant.Application;
using TheRestaurant.Application.Interfaces.IAllergy;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Application.Orders;
using TheRestaurant.Application.Orders.Interfaces;
using TheRestaurant.Application.Services.AllergyServices;
using TheRestaurant.Application.Services.ProductServices;
using TheRestaurant.Common.Infrastructure.Data;
using TheRestaurant.Common.Infrastructure.Repositories.Orders;
using TheRestaurant.Common.Infrastructure.Repositories.Product;
using TheRestaurant.Presentation.Client.Components.Admin.ProductCrud;
using TheRestaurant.Presentation.Server.Config.Swagger;

namespace TheRestaurant.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient();

            //Swagger
            builder.Services.AddSwaggerServices();

            // Persistence and DA
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddAuthServices(builder.Configuration);
            builder.Services.AddApplicationServices();



            builder.Services.AddTransient<IAllergyService, AllergyService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            // Add OrderService
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<DeleteProductConfirmation>();


            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseWebAssemblyDebugging();
                
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            SeedDataAsync(app).GetAwaiter().GetResult();

            app.Run();
        }


        private static async Task SeedDataAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var userSeeds = serviceProvider.GetRequiredService<UserSeeds>();
                await userSeeds.SeedManager();
                await userSeeds.SeedEmployee();

                var procutImageUpdater = serviceProvider.GetRequiredService<SeedImagesToProduct>();
                await procutImageUpdater.AddImagesToProductsAsync();
                
            }
        }
    }
}