using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using TheRestaurant.Contracts.Requests.Authentication;

namespace TheRestaurant.Presentation.Client.ClientServices
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;
        private readonly ClientCartService _clientCartService;

        public AuthService(HttpClient httpClient,
                           ILocalStorageService localStorage,
                           NavigationManager navigationManager,
                           ClientCartService clientCartService)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
            _clientCartService = clientCartService;
        }

        public event Action IsLoggedIn;

        public async Task UpdateAuthState()
        {
            IsLoggedIn?.Invoke();
        }

        public async Task<bool> Login(LoginRequest request)
        {
            var json = JsonSerializer.Serialize(request);

            var apiUrl = "/auth/login";

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                await _localStorage.SetItemAsync("authToken", token);

                // Invoke event to UI icons will change
                IsLoggedIn?.Invoke();

                // Set header to authorized so controller can authorize user
                _httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("bearer", token);

                // Logged in user cannot use cart -> remove cart-items from storage
                await _localStorage.RemoveItemAsync("CartItems");
                await _clientCartService.UpdateCartService();

                if (_navigationManager.Uri.Contains("login"))
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            return false;
        } 
    }
}
