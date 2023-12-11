using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Dashboard;

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [ApiController]
    [Route("Dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
		private readonly DashboardServices _dashboardServices;

		public DashboardController(
            ILogger<DashboardController> logger,
			DashboardServices dashboardServices)
        {
            _logger = logger;
			_dashboardServices = dashboardServices;
		}


		[HttpGet("GetWeeklyOrderStatistics")]
		public async Task<IActionResult> GetWeeklyOrderStatistics()
		{
			DateTime fromDate = DateTime.Now;
			var result = await _dashboardServices.GetWeeklyOrderStats(fromDate);
			if (!result.IsSuccess)
			{
				return BadRequest(result.ErrorResponse);
			}

			return Ok(result.Data);
		}
	}
}
