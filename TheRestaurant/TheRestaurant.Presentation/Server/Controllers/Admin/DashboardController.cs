using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Dashboard;
using TheRestaurant.Application.Employees;
using TheRestaurant.Presentation.Client.ClientServices;
using TheRestaurant.Presentation.Shared.Requests;

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
        public async Task<IActionResult> GetWeeklyOrderStatistics([FromQuery] DateTime? date)
        {
            // If no date is provided, use the current date
            DateTime fromDate = date ?? DateTime.Now;

            var result = await _dashboardServices.GetWeeklyOrderStats(fromDate);
            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorResponse);
            }

            return Ok(result.Data);
        }
    }
}
