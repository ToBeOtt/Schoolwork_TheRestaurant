using System.Net.Http.Json;
using TheRestaurant.Contracts.Responses.Orders;
using TheRestaurant.Presentation.Shared.DTO.Orders;

namespace TheRestaurant.Presentation.Client.ClientServices
{
    public class ClientOrderService
    {
        private readonly HttpClient _httpClient;

        public ClientOrderService
            (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCustomerOrderDTO> CheckOrderStatus(int id)
        {
            var apiUrl = $"/Order/GetCustomerOrder?id={id}";
            var orderDetails = await _httpClient.GetFromJsonAsync<GetCustomerOrderDTO>(apiUrl);

            return orderDetails;
        }

        public async Task CancelCustomerOrder(int id)
        {
            var apiUrl = $"/Order/CancelOrder/{id}";
            await _httpClient.DeleteAsync(apiUrl);
        }

        public async Task<List<ActiveOrdersDto>> FetchListOfActiveOrders()
        {
            var apiUrl = "/Order/FetchAllActiveOrders";
            var listOfOrders = await _httpClient.GetFromJsonAsync<List<ActiveOrdersDto>>(apiUrl);
            return listOfOrders;
        }

        public async Task<bool> SetStatusToFinished(int orderId)
        {
            var apiUrl = "/Order/SetStatusToFinished";
            var outcome = await _httpClient.PostAsJsonAsync(apiUrl, orderId);
            
            if (outcome.IsSuccessStatusCode)
                return true;

            else 
                return false;
        }
    }
}
