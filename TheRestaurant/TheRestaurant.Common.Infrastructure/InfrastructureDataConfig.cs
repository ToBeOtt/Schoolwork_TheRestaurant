using Common.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Application.Services;
using TheRestaurant.Application.Employees.Interfaces;
using TheRestaurant.Application.Interfaces.IAllergy;
using TheRestaurant.Authentication.Interfaces;
using TheRestaurant.Common.Infrastructure.Data;
using TheRestaurant.Common.Infrastructure.Repositories.Allergy;
using TheRestaurant.Common.Infrastructure.Repositories.Authentication;
using TheRestaurant.Common.Infrastructure.Repositories.Category;
using TheRestaurant.Common.Infrastructure.Repositories.Employees;

using TheRestaurant.Domain.Entities.Authentication;
using TheRestaurant.Application.Cart.Interfaces;
using TheRestaurant.Common.Infrastructure.Repositories.Cart;
using TheRestaurant.Application.Dashboard.Interfaces;
using TheRestaurant.Common.Infrastructure.Repositories.Dashboard;

namespace Common.Infrastructure
{
    public static class InfrastructureDataConfig
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
               throw new InvalidOperationException("Connection string not found.");

            services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer
                (connectionString));

            services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RestaurantDbContext>()
                .AddDefaultTokenProviders();

            // Authentication & Tokens
            services.AddAuth(configuration);

            // Other services
            services.AddHttpContextAccessor();

            //Repositories
            services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();

            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IDashboardRepository, DashboardRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IAllergyRepository, AllergyRepository>();

            // Seeds
            services.AddTransient<UserSeeds>();

            services.AddTransient<SeedImagesToProduct>();


            return services;
        }


        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");

            services.AddSingleton(Options.Create(jwtSettings));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes
                    (jwtSettings["SecretKey"])),
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"]
                };
            });

            services.AddTransient<IJwtTokenRepository, JwtTokenRepository>();

            return services;
        }
    }
}


