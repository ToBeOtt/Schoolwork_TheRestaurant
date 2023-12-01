using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheRestaurant.Application.Interfaces.IOrderStatus;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Common.Infrastructure.Repositories.OrderStatus
{
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly RestaurantDbContext _context;

        public OrderStatusRepository(RestaurantDbContext context)
        {
            _context = context;
        }


        //Get OrderStatus By Id
        public async Task<Domain.Entities.OrderEntities.OrderStatus> GetAsync(int id)
        {
            var orderStatus = await _context.Set<Domain.Entities.OrderEntities.OrderStatus>().FirstOrDefaultAsync(c => c.Id == id);
            return orderStatus;
        }

        //Get All OrderStatus
        public async Task<IReadOnlyList<Domain.Entities.OrderEntities.OrderStatus>> GetAllAsync()
        {
            var list = await _context.OrderStatus.ToListAsync();
            return list;
        }

        //Add new OrderStatus
        public async Task AddAsync(Domain.Entities.OrderEntities.OrderStatus orderStatus)
        {
            await _context.AddAsync(orderStatus);
            //await SaveChangesAsync();
        }

        //Update the OrderStatus
        public async Task UpdateAsync(Domain.Entities.OrderEntities.OrderStatus orderStatus)
        {
            _context.Update(orderStatus);
            //await SaveChangesAsync();
        }

        // Delete the OrderStatus
        public async Task DeleteAsync(Domain.Entities.OrderEntities.OrderStatus orderStatus)
        {
            _context.OrderStatus.Remove(orderStatus);
            //await SaveChangesAsync();
        }

        // Delete the OrderStatus By ID
        public async Task DeleteAsync(int id)
        {
            var orderStatus = await GetAsync(id);
            await DeleteAsync(orderStatus);
        }


        // Disable: Field IsDelete = True
        public async Task<bool> Disable(int id)
        {
            try
            {
                var orderStatus = await GetAsync(id);
                orderStatus.IsDeleted = true;
                await UpdateAsync(orderStatus);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        // Disable: Field IsDelete = False
        public async Task<bool> Enable(int id)
        {
            try
            {
                var orderStatus = await GetAsync(id);
                orderStatus.IsDeleted = true;
                await UpdateAsync(orderStatus);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        //Exists
        public bool Exists(int id)
        {
            return (_context.OrderStatus?.Any(o => o.Id == id)).GetValueOrDefault();
        }

        // SaveChanges
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
