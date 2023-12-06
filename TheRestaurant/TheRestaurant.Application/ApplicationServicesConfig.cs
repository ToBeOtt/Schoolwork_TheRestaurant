using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheRestaurant.Application.Cart;
using TheRestaurant.Application.Dashboard;
using TheRestaurant.Application.Employees;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Application.Services.OrderServices;
using TheRestaurant.Application.Services.ProductServices;

namespace TheRestaurant.Application
{
    public static class ApplicationServicesConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Repositories
            services.AddTransient<CartServices>();
            services.AddTransient<ProductService>();
            services.AddTransient<EmployeeServices>();
			services.AddTransient<DashboardServices>();
			
			return services;
        }


    }
}


