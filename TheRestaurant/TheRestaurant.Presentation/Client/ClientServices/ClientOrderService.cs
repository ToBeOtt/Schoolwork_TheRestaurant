using System.Net.Http.Json;
using TheRestaurant.Contracts.Responses.Orders;
using TheRestaurant.Presentation.Shared.DTO.Orders;
using TheRestaurant.Presentation.Shared.Requests.Order;

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


        public event Action OrdersUpdated;


        public async Task<GetCustomerOrderDTO> FetchOrder(int id)
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

        public async Task<List<FinishedOrderDto>> FetchListOfFinishedOrders()
        {
            var apiUrl = "/Order/FetchAllFinishedOrders";
            var listOfFinishedOrders = await _httpClient.GetFromJsonAsync<List<FinishedOrderDto>>(apiUrl);
            return listOfFinishedOrders;
        }

        public async Task<bool> UpdateOrderStatus(int orderId, string status)
        {
            ChangeOrderStatusRequest request = new(
                Id: orderId,
                OrderStatus: status);

            var apiUrl = "/Order/UpdateOrderStatus";
            var outcome = await _httpClient.PostAsJsonAsync(apiUrl, request);

            if (outcome.IsSuccessStatusCode)
            {
                OrdersUpdated?.Invoke();
                return true;
            }
                
            else
                return false;
        }

    }
}
