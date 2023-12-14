using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using TheRestaurant.Presentation.Shared.DTO.Dashboard;
using TheRestaurant.Presentation.Shared.DTO.Employees;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static TheRestaurant.Presentation.Client.Pages.Admin.Index.Earnings;

namespace TheRestaurant.Presentation.Client.ClientServices
{
	public class ClientDashboardServices
	{
		private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
		private readonly ILocalStorageService _localStorage;


		public ClientDashboardServices
			(HttpClient httpClient,
			NavigationManager navigationManager,
			ILocalStorageService localStorage)
		{
			_httpClient = httpClient;
			_navigationManager = navigationManager;
			_localStorage = localStorage;
		}

		public async Task<List<OrderCountDto>> GetWeeklyOrderStats(DateTime date)
		{
            var apiUrl = $"/Dashboard/GetWeeklyOrderStatistics?date={date.ToString("yyyy-MM-dd")}";
            var listOfWeeklySalesNrs = 
				await _httpClient.GetFromJsonAsync<List<OrderCountDto>>(apiUrl);

			return listOfWeeklySalesNrs;
		}

        public async Task<List<OrderCountByHourDto>> GetOrderStatsByHour()
        {
            try
            {
                var responseWrapper = await _httpClient.GetFromJsonAsync<ApiResponse<List<OrderCountByHourDto>>>("Dashboard/GetOrderStatsByHour");
                if (responseWrapper != null && responseWrapper.IsSuccess)
                {
                    var data = responseWrapper.Data;
                    Console.WriteLine("Data from service:", data);
                    return data;
                }
                else
                {
                    // Handle error or return an empty list
                    return new List<OrderCountByHourDto>();
                }
            }
            catch (Exception ex)
            {
                return new List<OrderCountByHourDto>();
            }
        }

        public async Task<List<ProductSaleCountDto>> GetProductSaleCountAsync()
        {
            var responseWrapper = await _httpClient.GetFromJsonAsync<ApiResponse<List<ProductSaleCountDto>>>("Dashboard/GetProductSaleCount");
            if (responseWrapper != null && responseWrapper.IsSuccess)
            {
                return responseWrapper.Data;
            }
            else
            {
                // Handle error or return an empty list
                return new List<ProductSaleCountDto>();
            }
        }



    }
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }

}
