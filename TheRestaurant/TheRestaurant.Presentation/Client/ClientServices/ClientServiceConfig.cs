using TheRestaurant.Presentation.Client.ClientServices;

namespace Common.Infrastructure
{
    public static class ClientServiceConfig
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<RoleService>();
            services.AddScoped<AuthService>();
            services.AddScoped<TokenExpirationChecker>();
            services.AddScoped<ClientEmployeeServices>();
            return services;
        }
      
    }
}


