using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Application.Orders.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<bool> CreateOrderRow(OrderRow orderRow);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order Order);


        // Order-Queries
        Task<Order> GetByIdAsync(int orderId);
        Task<List<Order>> GetAllAsync();
        Task<List<Order>> GetActiveOrders();


        // Order-status handling
        Task<OrderStatus> GetPendingStatusId();
    }
}
