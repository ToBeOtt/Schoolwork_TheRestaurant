using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using TheRestaurant.Presentation.Shared.DTO.Dashboard;
using TheRestaurant.Presentation.Shared.DTO.Employees;

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
			var apiUrl = "/Dashboard/GetWeeklyOrderStatistics";
			var listOfWeeklySalesNrs = 
				await _httpClient.GetFromJsonAsync<List<OrderCountDto>>(apiUrl);

			return listOfWeeklySalesNrs;
		}




	}
}
