using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.ServiceResponse;
using TheRestaurant.Application.Dashboard;
using TheRestaurant.Application.Employees;
using TheRestaurant.Application.Orders;
using TheRestaurant.Application.Orders.Interfaces;
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
        private readonly OrderService _orderService;

        public DashboardController(
            ILogger<DashboardController> logger,
			DashboardServices dashboardServices,
            OrderService orderService)
        {
            _logger = logger;
			_dashboardServices = dashboardServices;
            _orderService = orderService;
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

        [HttpGet("GetOrderStatsByHour")]
        public async Task<ActionResult<ServiceResponse<List<OrderCountByHourDto>>>> GetOrderStatsByHour()
        {
            var response = await _orderService.GetOrderStatsByHour();
            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }



        [HttpGet("GetProductSaleCount")]
        public async Task<ActionResult<ServiceResponse<List<ProductSaleCountDto>>>> GetProductSaleCount()
        {
            var response = await _orderService.GetProductSaleCounts();
            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }
    }
}
