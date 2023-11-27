using Authentication;
using Common.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Application.Services;
using TheRestaurant.Common.Infrastructure.Repositories.Item;
using TheRestaurant.Presentation.Client.Components.Admin.ItemCrud;
using Microsoft.Extensions.DependencyInjection;
using TheRestaurant.Common.Infrastructure.Data;
using TheRestaurant.Application.Interfaces.IAllergy;
using TheRestaurant.Application.Services.AllergyServices;

namespace TheRestaurant.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddHttpClient();

            // Persistence and DA
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddAuthServices(builder.Configuration);


            builder.Services.AddTransient<IAllergyService, AllergyService>();
            builder.Services.AddScoped<IItemService, ItemService>();
            builder.Services.AddScoped<IItemRepository, ItemRepository>();

            builder.Services.AddScoped<DeleteItemConfirmation>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
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
            }
        }
    }
}