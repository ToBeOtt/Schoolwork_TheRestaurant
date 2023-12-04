using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TheRestaurant.Presentation.Shared.DTO.Cart;
using TheRestaurant.Presentation.Shared.DTO.Product;
using TheRestaurant.Presentation.Shared.Requests;

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
    }
}
