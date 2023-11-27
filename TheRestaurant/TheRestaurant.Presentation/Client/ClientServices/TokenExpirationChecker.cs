using Blazored.LocalStorage;
using Microsoft.Extensions.Hosting;
using TheRestaurant.Presentation.Client.Helpers;

namespace TheRestaurant.Presentation.Client.ClientServices
{
    public class TokenExpirationChecker : BackgroundService
    {
        private readonly ILocalStorageService _localStorage;

        public TokenExpirationChecker(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Check the expiration time periodically
                var expirationTime = await TokenHelper.GetTokenExpirationTime(_localStorage);

                // Reset expiration time
                if(expirationTime < DateTimeOffset.UtcNow)
                {
                    await _localStorage.RemoveItemAsync("authToken");
                    await _localStorage.RemoveItemAsync("TokenExpiration");
                }
              
                // Sleep before checking again
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }
    }
}
