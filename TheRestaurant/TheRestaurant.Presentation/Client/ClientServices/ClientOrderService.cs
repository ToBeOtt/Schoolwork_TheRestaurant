using System.Net.Http.Json;
using TheRestaurant.Contracts.Responses.Orders;

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
    }
}
