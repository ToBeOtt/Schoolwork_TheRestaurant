using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheRestaurant.Application.Orders.Interfaces;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Common.Infrastructure.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public OrderRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<bool> CreateOrderRow(OrderRow orderRow)
        {
            _dbContext.OrderRows.Add(orderRow);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _dbContext.Orders.FindAsync(orderId);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<OrderStatus> GetPendingStatusId()
        {
            var status = await _dbContext.OrderStatus
                                    .Where(x => x.Status == "Pending")
                                    .SingleOrDefaultAsync();
            return status;
        }

        public async Task<List<Order>> GetOrdersByStatus(string status)
        {
            var orders = await _dbContext.Orders.Where(x => x.OrderStatus.Status == status).ToListAsync();
            return orders;
        }
    }
}
