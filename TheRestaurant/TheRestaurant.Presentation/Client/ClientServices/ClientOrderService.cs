using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace TheRestaurant.Presentation.Client.ClientServices
{
    public class ClientOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;

        public ClientOrderService
            (HttpClient httpClient,
            NavigationManager navigationManager,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _localStorage = localStorage;
        }

        public async Task<int> CheckOrderStatus(int orderNr)
        {
            // Implementera relevant logik.
            return 0;
        }
    }
}
