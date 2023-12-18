using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TheRestaurant.Application.Dashboard;
using TheRestaurant.Application.Orders;
using TheRestaurant.Contracts.Responses.ServiceResponse;
using TheRestaurant.Presentation.Shared.DTO.Dashboard;

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


        [HttpGet("GetOrderStatsByDateRange")]
        public async Task<ActionResult<ServiceResponse<List<OrderCountDto>>>> GetOrderStatsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            _logger.LogInformation($"Received URL: {Request.GetDisplayUrl()}");
            _logger.LogInformation($"Received start date: {startDate}");
            _logger.LogInformation($"Received end date: {endDate}");
            var response = await _orderService.GetOrderStatsByDateRange(startDate, endDate);
            if (!response.IsSuccess)
            {
                return BadRequest(response.ErrorMessage);
            }
            return Ok(response);
        }


        [HttpGet("GetOrderStatsByUserChosenDate")]
        public async Task<ActionResult<ServiceResponse<List<OrderCountByHourDto>>>> GetOrderStatsByUserChosenDate([FromQuery] DateTime selectedDate)
        {

            var response = await _orderService.GetOrderStatsByUserChosenDate(selectedDate);
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
