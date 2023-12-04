using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Application.DTOs;
using TheRestaurant.Application.Services.OrderServices;
using TheRestaurant.Domain.Entities.OrderEntities;
using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Presentation.Server.Controllers.Admin;
using TheRestaurant.Application.DTOs;

namespace TheRestaurant.Presentation.Server.Controllers.Order
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
       
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDto = new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate
            };

            return orderDto;
        }
        [HttpPost("create")]
        public async Task<ActionResult<OrderDTO>> CreateOrder([FromBody] OrderDTO orderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Directly pass the OrderDTO to the service
                var createdOrder = await _orderService.CreateOrderAsync(orderDto);

                // Optionally, map the created Order back to DTO for the response
                OrderDTO createdOrderDto = MapEntityToDto(createdOrder);

                return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrderDto);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the order.");
            }
        }

        private OrderDTO MapEntityToDto(Domain.Entities.OrderEntities.Order order)
        {
            return new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                // ... other property mappings
            };
        }


        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

    }

}
