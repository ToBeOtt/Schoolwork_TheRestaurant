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

        public async Task<List<OrderCountByHourDto>> GetOrderStatsByUserChosenDate(DateTime selectedDate)
        {
            try
            {
                string formattedDate = selectedDate.ToString("yyyy-MM-dd");
                string requestUri = $"Dashboard/GetOrderStatsByUserChosenDate?selectedDate={formattedDate}";

                System.Diagnostics.Debugger.Break();

                var responseWrapper = await _httpClient.GetFromJsonAsync<ApiResponse<List<OrderCountByHourDto>>>(requestUri);
                if (responseWrapper != null && responseWrapper.IsSuccess)
                {
                    var data = responseWrapper.Data;
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

        public async Task<List<OrderCountDto>> GetOrderStatsByDateRange(DateTime orderStartDate, DateTime orderEndDate)
        {
            try
            {
                string formattedStartDate = orderStartDate.ToString("yyyy-MM-dd");
                string formattedEndDate = orderEndDate.ToString("yyyy-MM-dd");
                string requestUri = $"Dashboard/GetOrderStatsByDateRange?startDate={formattedStartDate}&endDate={formattedEndDate}";


                var responseWrapper = await _httpClient.GetFromJsonAsync<ApiResponse<List<OrderCountDto>>>(requestUri);
                if (responseWrapper != null && responseWrapper.IsSuccess)
                {
                    var data = responseWrapper.Data;
                    return data;
                }
                else
                {
                    // Handle error or return an empty list
                    return new List<OrderCountDto>();
                }
            }
            catch (Exception ex)
            {
                return new List<OrderCountDto>();
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
