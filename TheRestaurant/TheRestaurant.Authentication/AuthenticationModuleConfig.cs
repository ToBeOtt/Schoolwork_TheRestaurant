using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheRestaurant.Authentication.Services.AuthenticationServices;
using TheRestaurant.Authentication.Services.RegistrationServices;
using TheRestaurant.Authentication.Services.RoleServices;

namespace Authentication
{
    public static class AuthenticationModuleConfig
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<AuthenticationService>();
            services.AddTransient<RegistrationService>();
            services.AddTransient<RoleService>();

            return services;
        }
    }
}

