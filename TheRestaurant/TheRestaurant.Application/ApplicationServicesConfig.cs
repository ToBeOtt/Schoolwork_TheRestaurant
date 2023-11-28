using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheRestaurant.Application.Employees;

namespace TheRestaurant.Application
{
    public static class ApplicationServicesConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Repositories
            services.AddTransient<EmployeeServices>();
            return services;
        }


    }
}


