using TheRestaurant.Presentation.Client.ClientServices;
using TheRestaurant.Presentation.Client.Helpers;

namespace TheRestaurant.Presentation.Client
{
    public static class ClientServiceConfig
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddScoped<RoleService>();
            services.AddScoped<AuthService>();
            services.AddScoped<ClientMenuService>();
            services.AddScoped<ClientEmployeeServices>(); 

            // Helpers
            services.AddScoped<CheckRole>();

            return services;
        }

    }
}


