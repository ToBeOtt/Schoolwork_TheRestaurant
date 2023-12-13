using TheRestaurant.Contracts.Responses;

namespace TheRestaurant.Application.Dashboard.Interfaces
{
    public interface IDashboardRepository
	{
		//Task<List<OrderCountResponse>> GetLastDaysOrders(DateTime fromDate);

        Task<List<OrderCountResponse>> GetLastDaysOrderCounts(DateTime fromDate);
    }
}
