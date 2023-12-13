using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheRestaurant.Application.Dashboard.Interfaces;
using TheRestaurant.Common.Infrastructure.Repositories.Cart;
using TheRestaurant.Contracts.Responses;

namespace TheRestaurant.Common.Infrastructure.Repositories.Dashboard
{
    public class DashboardRepository : IDashboardRepository
	{
		private readonly ILogger<CartRepository> _logger;
		private readonly RestaurantDbContext _context;

		public DashboardRepository
			(ILogger<CartRepository> logger,
			RestaurantDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		public async Task<List<OrderCountResponse>> GetLastDaysOrderCounts(DateTime fromDate)
		{
            var result = await _context.Orders
					.Where(o => o.OrderDate >= fromDate.AddDays(-6) && o.OrderDate <= fromDate)
					.GroupBy(o => o.OrderDate.Date)
					.OrderBy(g => g.Key)
					.Select(g => new OrderCountResponse(
						g.Key.ToString("yyyy-MM-dd"),
						Convert.ToDouble(g.Count())
					))
					.ToListAsync();

			return result;
		}

        //Task<List<OrderCountResponse>> IDashboardRepository.GetLastDaysOrders(DateTime fromDate)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
