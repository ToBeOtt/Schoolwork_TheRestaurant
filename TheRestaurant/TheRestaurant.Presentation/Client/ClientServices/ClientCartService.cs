using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using TheRestaurant.Presentation.Client.Pages.Order.OrderDTO;
using TheRestaurant.Presentation.Shared.DTO.Cart;
using TheRestaurant.Presentation.Shared.OrderDTO;
using TheRestaurant.Presentation.Shared.Requests;

namespace TheRestaurant.Presentation.Client.ClientServices
{
    public class ClientCartService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorage;

        public ClientCartService
            (HttpClient httpClient,
            NavigationManager navigationManager,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _localStorage = localStorage;
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

            GetCartItemRequest request = new GetCartItemRequest(ListOfId: existingCartItems);

            var apiUrl = "/cart/GetProductsForCart";

            var response = await _httpClient.PostAsJsonAsync(apiUrl, request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<CartDto>>();

                return result;
            }

            else
                return null;
        }
        public async Task<List<AggregatedCartDto>> SortCartItems(List<CartDto> listToSort)
        {
            var groupedCartItems = listToSort
                                .GroupBy(item => new { item.Id, item.Name })
                                .Select(group => new
                                {
                                    Id = group.Key.Id,
                                    Name = group.Key.Name,
                                    TotalPrice = group.Sum(item => (double)item.Price),
                                    Count = group.Count()
                                })
                                .ToList();

            groupedCartItems.Select(item => (item.Name, item.TotalPrice)).ToList();

            List<AggregatedCartDto> SortedList = new();
            foreach (var groupedItem in groupedCartItems)
            {
                AggregatedCartDto dto = new(groupedItem.Id, groupedItem.Name, groupedItem.TotalPrice, groupedItem.Count);
                SortedList.Add(dto);
            }
            return SortedList;
        }

        public async Task<double> TotalPriceOfCartItems(List<double> prices)
        {
            double totalPriceToPay = 0;
            foreach (var price in prices)
            {
                totalPriceToPay = +totalPriceToPay + price;
            }
            return totalPriceToPay;
        }

        public void ClearCart()
        {
            _localStorage.RemoveItemAsync("CartItems");
            _navigationManager.NavigateTo("/Cart");
        }

        public async Task<bool> DeleteCartItem(int itemToRemove)
        {
            var cartItems = await _localStorage.GetItemAsync<List<int>>("CartItems");

            if (cartItems != null)
            {
                int indexToRemove = cartItems.IndexOf(itemToRemove);
                if (indexToRemove != -1)
                {
                    cartItems.RemoveAt(indexToRemove);
                    await _localStorage.SetItemAsync("CartItems", cartItems);
                    return true;
                }
            }

            return false;
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

                CartUpdated?.Invoke();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task UpdateCartService()
        {
            CartUpdated?.Invoke();
        }

        public async Task<bool> PlaceOrder(string comment, List<AggregatedCartDto> listOfOrderItems)
        {
            List<OrderProductDto> cartItemsForOrder = new List<OrderProductDto>();
            foreach (var item in listOfOrderItems)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    cartItemsForOrder.Add(new OrderProductDto
                    {
                        Id = item.IdOfOrderAggregate,
                        Name = item.Name,
                        Price = item.TotalPrice / item.Count,
                        Count = 1
                    });
                }
            }

            var order = new OrderDto
            {
                Id = 123,
                OrderDate = DateTime.Now,
                OrderStatus = "Pending",
                Comment = comment,
                CartItems = cartItemsForOrder
            };


            // Send the order to the server
            var apiUrl = "/api/Order/create";
            var response = await _httpClient.PostAsJsonAsync(apiUrl, order);

            // Check if the order was successfully placed
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
