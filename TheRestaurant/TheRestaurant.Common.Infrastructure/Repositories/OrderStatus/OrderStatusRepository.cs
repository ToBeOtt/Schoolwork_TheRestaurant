using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces.IOrderStatus;

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
        public async Task<Domain.Entities.Orders.OrderStatus> GetAsync(int id)
        {
            var orderStatus = await _context.Set<Domain.Entities.Orders.OrderStatus>().FirstOrDefaultAsync(c => c.Id == id);
            return orderStatus;

        }

        //Get OrderStatus By Status
        public async Task<Domain.Entities.Orders.OrderStatus> GetAsync(string status)
        {
            return await _context.OrderStatus
                                    .Where(x => x.Status == status)
                                    .SingleOrDefaultAsync();
        }


        //Get All OrderStatus
        public async Task<IReadOnlyList<Domain.Entities.Orders.OrderStatus>> GetAllAsync()
        {
            var list = await _context.OrderStatus.ToListAsync();
            return list;
        }


        //Add new OrderStatus
        public async Task<Domain.Entities.Orders.OrderStatus> AddAsync(Domain.Entities.Orders.OrderStatus orderStatus)
        {
            await _context.AddAsync(orderStatus);
            return orderStatus;
        }

        //Update the OrderStatus
        public async Task<Domain.Entities.Orders.OrderStatus> UpdateAsync(Domain.Entities.Orders.OrderStatus orderStatus)
        {
            _context.Update(orderStatus);
            return orderStatus;
        }

        // Delete the OrderStatus
        public async Task<Domain.Entities.Orders.OrderStatus> DeleteAsync(Domain.Entities.Orders.OrderStatus orderStatus)
        {
            _context.OrderStatus.Remove(orderStatus);
            return orderStatus;

        }

        // Delete the OrderStatus By ID
        public async Task<Domain.Entities.Orders.OrderStatus> DeleteAsync(int id)
        {
            var orderStatus = await GetAsync(id);
            _context.OrderStatus.Remove(orderStatus);
            return orderStatus;
        }

        //Exists
        public bool Exists(int id)
        {
            return (_context.OrderStatus?.Any(o => o.Id == id)).GetValueOrDefault();
        }


        // Save Changes
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
