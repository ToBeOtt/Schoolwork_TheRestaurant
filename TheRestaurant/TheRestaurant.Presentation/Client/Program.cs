using Blazored.LocalStorage;
using Common.Infrastructure;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using System.Net.NetworkInformation;
using TheRestaurant.Presentation.Client;
using TheRestaurant.Presentation.Client.ClientServices;

namespace TheRestaurant.Presentation.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Client-side Authentication and authorization
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            
            //builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
            builder.Services.AddScoped<ServerAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(
                provider => provider.GetRequiredService<ServerAuthenticationStateProvider>());

             


            // All services for client
            builder.Services.AddClientServices(builder.Configuration);
            
            // For using local storage with authentication
            builder.Services.AddBlazoredLocalStorage();

            // UI-component library
            builder.Services.AddMudServices();

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
