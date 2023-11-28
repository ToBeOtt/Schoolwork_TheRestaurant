using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Presentation.Shared.OrderDTO;
using TheRestaurant.Application.Services.OrderServices;

namespace TheRestaurant.Presentation.Server.Controllers.Order
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var orderDto = new OrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate
            };

            return orderDto;
        }
        [HttpPost("CreateOrder")]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
        {
            var order = new Domain.Entities.OrderEntities.Order
            {
                Id = orderDto.Id,
                OrderDate = orderDto.OrderDate,
                //OrderItems = orderDto.OrderItems // TODO OrderItems is a list of OrderItem objects
            };

            var createdOrder = await _orderService.CreateOrderAsync(order);
            if (createdOrder == null)
            {
                return NotFound();
            }

            // Set the status of the order
            _orderService.SetOrderStatus(createdOrder, "Pending");

            var createdOrderDto = new OrderDto
            {
                Id = createdOrder.Id,
                OrderDate = createdOrder.OrderDate,
                OrderStatus = createdOrder.OrderStatus.Status // Access the status from the OrderStatus object
            };

            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrderDto);
        }




        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

    }

}
