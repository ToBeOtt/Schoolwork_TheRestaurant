using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Application.Orders.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<bool> CreateOrderRow(OrderRow orderRow);
        Task<bool> UpdateAsync(Order order);
        Task DeleteAsync(Order Order);


        // Order-Queries
        Task<Order> GetByIdAsync(int orderId);
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetPendingOrders();
        Task<List<Order>> GetActiveOrders();
        Task<List<Order>> GetFinishedOrders();
        Task<List<ProductSaleCountDto>> GetProductSaleCount();

        Task<List<OrderCountByHourDto>> GetOrderStatsByHour();




        // Order-status handling
        Task<OrderStatus> GetOrderStatusByName(string statusName);
        Task<List<Order>> GetOrdersByStatus(string status);

    }
}
