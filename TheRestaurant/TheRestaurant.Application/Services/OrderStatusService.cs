using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces.ICategory;
using TheRestaurant.Application.Interfaces.IOrderStatus;
using TheRestaurant.Contracts.DTOs;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Application.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }


        // Get All 
        public async Task<IReadOnlyList<OrderStatusDto>> GetAllAsync()
        {
            var listOrderStatus = await _orderStatusRepository.GetAllAsync();
            if (listOrderStatus == null)
            {
                return null;
            }

            var listOrderStatusDto = listOrderStatus.Select(o => new OrderStatusDto()
            {
                Id = o.Id,
                Status = o.Status,
                IsDeleted = o.IsDeleted,
            }).ToList();

            return listOrderStatusDto;
        }

        // Get All By Id
        public async Task<OrderStatusDto> GetAsync(int id)
        {
            var orderStatus = await _orderStatusRepository.GetAsync(id);
            if (orderStatus == null)
            {
                return null;
            }
            var orderStatusDto = new OrderStatusDto()
            {
                Id = orderStatus.Id,
                Status = orderStatus.Status,
                IsDeleted = orderStatus.IsDeleted,
            };

            return orderStatusDto;
        }

        // Add 
        public async Task<bool> AddAsync(OrderStatusDto orderStatusDto)
        {
            try
            {

                OrderStatus orderstatus = new OrderStatus()
                {
                    Id = orderStatusDto.Id,
                    Status = orderStatusDto.Status,
                    IsDeleted = orderStatusDto.IsDeleted,
                };

                await _orderStatusRepository.AddAsync(orderstatus);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        //Update
        public async Task<bool> UpdateAsync(OrderStatusDto orderStatusDto)
        {
            try
            {
                OrderStatus orderstatus = new OrderStatus()
                {
                    Id = orderStatusDto.Id,
                    Status = orderStatusDto.Status,
                    IsDeleted = orderStatusDto.IsDeleted,
                };

                await _orderStatusRepository.UpdateAsync(orderstatus);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }


        }


        // Delete By ID
        public async Task<bool> DeleteAsync(int id)
        {

            try
            {
                await _orderStatusRepository.DeleteAsync(id);
                await SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // Disable
        public async Task<bool> Disable(int id)
        {
            try
            {
                OrderStatusDto orderStatus = await GetAsync(id);
                orderStatus.IsDeleted = true;

                await UpdateAsync(orderStatus);
                await SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // Enable
        public async Task<bool> Enable(int id)
        {
            try
            {
                OrderStatusDto orderStatus = await GetAsync(id);
                orderStatus.IsDeleted = false;

                await UpdateAsync(orderStatus);
                await SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // SaveChange
        private async Task SaveChangesAsync()
        {
            await _orderStatusRepository.SaveChangesAsync();
        }

        //Exists
        public bool Exists(int id)
        {
            return _orderStatusRepository.Exists(id);
        }

    }
}
