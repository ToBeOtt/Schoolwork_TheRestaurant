using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Common.Infrastructure.Repositories.OrderRepository
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
            if (order == null)
            {
                throw new ArgumentException("Invalid order data");
            }

            // Additional validation logic here

            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
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

        Task<Order> IOrderRepository.CreateAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateOrderRow(OrderRow orderRow)
        {
            _dbContext.OrderRows.Add(orderRow);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        Task<Order> IOrderRepository.GetByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        Task<List<Order>> IOrderRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task IOrderRepository.UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }

        Task IOrderRepository.DeleteAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
