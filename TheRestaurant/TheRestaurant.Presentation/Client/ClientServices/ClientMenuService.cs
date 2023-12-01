using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using TheRestaurant.Presentation.Client.Components.Admin.Employees.Dto;
using TheRestaurant.Presentation.Client.Components.Menu.Dto;
using TheRestaurant.Presentation.Shared.Requests;
using TheRestaurant.Presentation.Shared.ViewModels;

namespace TheRestaurant.Presentation.Client.ClientServices
{
    public class ClientMenuService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;

        public ClientMenuService
            (HttpClient httpClient,
            NavigationManager navigationManager,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _localStorage = localStorage;
        }

        public async Task<List<ClientProductDto>> GetAllMenuItems()
        {
            var apiUrl = "/products/GetProducts";
            var listOfProducts = await _httpClient.GetFromJsonAsync<List<ClientProductDto>>(apiUrl);

            List<ClientProductDto> listOfMappedProducts = new();

            foreach (var product in listOfProducts)
            {
                ClientProductDto dto = new(
                   Id: product.Id,
                   Name: product.Name,
                   Price: product.Price,
                   IsFoodItem: product.IsFoodItem,
                   Description: product.Description,
                   MenuPhoto: product.MenuPhoto,
                   Category: product.Category,
                   Allergen: product.Allergen);
                listOfMappedProducts.Add(dto);
            }
            return listOfMappedProducts;
        }

        public async Task<List<string>> GetCategories()
        {
            var apiUrl = "/products/GetCategoriesForProducts";
            var listOfCategories = await _httpClient.GetFromJsonAsync<List<string>>(apiUrl);

            return listOfCategories;
        }


        public event Action CartUpdated;
        public async Task AddItemToCartService(int cartItemId)
        {
            try
            {
                var existingCartItems = await _localStorage.GetItemAsync<List<int>>("CartItems");

                if (existingCartItems != null)
                {
                    existingCartItems.Add(cartItemId);
                    await _localStorage.SetItemAsync("CartItems", existingCartItems);
                }
                else
                {
                    await _localStorage.SetItemAsync("CartItems", new List<int> { cartItemId });
                }

                // Notify subscribers that the cart is updated
                CartUpdated?.Invoke();
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public async Task<int> NrOfItemsInCart()
        {
            var existingCartItems = await _localStorage.GetItemAsync<List<int>>("CartItems");

            if (existingCartItems == null)
            {
                return 0;
            }

            else
                return existingCartItems.Count;
        }

        public async Task<List<CartDto>> GetAllCartItems()
        {
            var existingCartItems = await _localStorage.GetItemAsync<List<int>>("CartItems");

            if (existingCartItems == null)
            {
                // error handling
            }

            GetCartItemRequest request = new(
                ListOfId: existingCartItems);

            var apiUrl = "/cart/GetProductsForCart";

            var json = JsonSerializer.Serialize(request);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(apiUrl, content);

            response.EnsureSuccessStatusCode();

            var resultJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CartDto>>(resultJson);

            return result;
        }
    }
}
