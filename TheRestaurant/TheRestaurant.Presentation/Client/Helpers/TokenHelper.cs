using Blazored.LocalStorage;
using System;

namespace TheRestaurant.Presentation.Client.Helpers
{
   
    public static class TokenHelper
    {
        public static async Task<DateTimeOffset> GetTokenExpirationTime(ILocalStorageService localStorage)
        {
            var expirationTime = await localStorage.GetItemAsync<DateTimeOffset?>("TokenExpiration");

            // Check if the expiration time is valid
            if (expirationTime.HasValue && expirationTime > DateTimeOffset.UtcNow)
            {
                return expirationTime.Value;
            }

            return DateTimeOffset.MinValue;
        }
    }
}
