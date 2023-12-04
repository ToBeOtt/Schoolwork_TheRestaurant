using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheRestaurant.Application.Employees;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Application.Services.ProductServices;

namespace TheRestaurant.Application
{
    public static class ApplicationServicesConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IProductRepository>();
            services.AddTransient<EmployeeServices>();
            return services;
        }


    }
}


