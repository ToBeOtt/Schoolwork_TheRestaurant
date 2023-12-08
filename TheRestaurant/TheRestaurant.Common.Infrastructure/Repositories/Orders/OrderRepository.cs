using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheRestaurant.Application.Orders.Interfaces;
using TheRestaurant.Domain.Entities.Orders;

namespace TheRestaurant.Common.Infrastructure.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(
            RestaurantDbContext dbContext,
            ILogger<OrderRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
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
            return await _dbContext.Orders
                .Include(x => x.OrderRows)
                    .ThenInclude(o => o.Product)
                .Include(x => x.OrderStatus)
                .Where(x => x.Id == orderId && x.IsDeleted != true).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            _dbContext.Orders.Update(order);

            try
            {
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogInformation(ex.Message);
                return false;
            }
        }

        public async Task DeleteAsync(Order order)
        {
            _dbContext.Orders.Update(order);
            await _dbContext.SaveChangesAsync(); 
        }

        public async Task<OrderStatus> GetPendingStatusId()
        {
            var status = await _dbContext.OrderStatus
                                    .Where(x => x.Status == "Pending")
                                    .SingleOrDefaultAsync();
            return status;
        }


        public async Task<List<Order>> GetActiveOrders()
        {
            return await _dbContext.Orders
                           .Include(x => x.OrderRows)
                               .ThenInclude(o => o.Product)
                           .Include(x => x.OrderStatus)
                           .Where(x => x.OrderStatus.Status == "Active" && x.IsDeleted != true)
                           .ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByStatus(string status)
        {
            var orders = await _dbContext.Orders.Where(x => x.OrderStatus.Status == status).ToListAsync();
            return orders;

        }

        public async Task<OrderStatus> GetDeliveredStatusId()
        {
            var status = await _dbContext.OrderStatus
                                   .Where(x => x.Status == "Delivered")
                                   .SingleOrDefaultAsync();
            return status;
        }
    }
}
