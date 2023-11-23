using Authentication;
using Common.Infrastructure;
using Microsoft.AspNetCore.ResponseCompression;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Application.Services;
using TheRestaurant.Common.Infrastructure.Repositories.MenuItem;
using TheRestaurant.Presentation.Client.Components.Admin.MenuItemCrud;

namespace TheRestaurant.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Persistence and DA
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddAuthServices(builder.Configuration);

            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
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


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
