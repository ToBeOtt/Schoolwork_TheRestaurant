using Microsoft.Extensions.Logging;
using SharedKernel.Application.ServiceResponse;
using TheRestaurant.Application.Dashboard.Interfaces;
using TheRestaurant.Contracts.Responses;

namespace TheRestaurant.Application.Dashboard
{
	public class DashboardServices
	{
		private readonly ILogger<DashboardServices> _logger;
		private readonly IDashboardRepository _dashboardRepository;

		public DashboardServices
			(ILogger<DashboardServices> logger,
			IDashboardRepository dashboardRepository
			)
		{
			_logger = logger;
			_dashboardRepository = dashboardRepository;
		}

		public async Task<ServiceResponse<List<OrderCountResponse>>> GetWeeklyOrderStats
			(DateTime fromDate)
		{
			ServiceResponse<List<OrderCountResponse>> response = new();

            var result = await _dashboardRepository.GetLastDaysOrderCounts(fromDate);

            response.Data = result;

            return await response.SuccessResponse(response, response.Data);
		}

		
	}
}
