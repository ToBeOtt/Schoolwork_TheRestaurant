using Authentication;
using Common.Infrastructure;
using Microsoft.AspNetCore.Http.Features;

namespace TheRestaurant
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Persistence and DA
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddAuthServices(builder.Configuration);
            

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddControllers();


            var app = builder.Build();

            app.UseBlazorFrameworkFiles();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());

            app.UseRouting();

            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            };

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllers();

            app.Run();
        }
    }
}