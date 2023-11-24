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


        public AuthService(HttpClient httpClient,
                           ILocalStorageService localStorage,
                           NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navigationManager = navigationManager;
        }
        public async Task Login(LoginRequest request)
        {
            var json = JsonSerializer.Serialize(request);

            var apiUrl = "/auth/login";

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();

                await _localStorage.SetItemAsync("authToken", token);

                _httpClient.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("bearer", token);

                if (_navigationManager.Uri.Contains("login"))
                {
                    _navigationManager.NavigateTo("/");
                }
            }
            else
            {
                _navigationManager.NavigateTo("/register");
            }
            
        } 
    }
}
