using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Application.Orders.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<bool> CreateOrderRow(OrderRow orderRow);
        Task<Order> GetByIdAsync(int orderId);
        Task<List<Order>> GetAllAsync();
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order Order);


        // Order-status handling
        Task<OrderStatus> GetPendingStatusId();
    }
}
