using Microsoft.AspNetCore.Http;
using TheRestaurant.Contracts.Responses;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Application.Dashboard.Interfaces
{
    public interface IDashboardRepository
	{
		Task<List<OrderCountResponse>> GetLastDaysOrders(DateTime fromDate);
	}
}
