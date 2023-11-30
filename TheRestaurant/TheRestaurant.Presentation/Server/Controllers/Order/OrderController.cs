using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Presentation.Shared.OrderDTO;
using TheRestaurant.Application.Services.OrderServices;
using TheRestaurant.Presentation.Client.Pages.Order.OrderDTO;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Presentation.Server.Controllers.Order
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
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
        [HttpPost("Create")]
        public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] OrderDto orderDto)
        {
            var createOrderRequest = new CreateOrderRequest
            {
                OrderDate = orderDto.OrderDate,
                OrderItems = orderDto.OrderItems.Select(item => new OrderProductDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                }).ToList()
            };

            var order = new Domain.Entities.OrderEntities.Order
            {
                OrderDate = orderDto.OrderDate,
                OrderRows = new List<OrderRow>()
            };

            foreach (var orderItemDto in orderDto.OrderItems)
            {
                // You don't need to create detailed product entities here,
                // only include the ProductId and Quantity
                var orderRow = new OrderRow
                {
                    // Include the ProductId and Quantity
                    MenuItem = new List<Domain.Entities.Menu.Product>
            {
                new Domain.Entities.Menu.Product
                {
                    Id = orderItemDto.ProductId,
                    Name = "Product Name",
                    Price = 0,
                    IsFoodItem = false,
                    IsDeleted = false
                }
            }
                };

                order.OrderRows.Add(orderRow);
            }

            // Set the status of the order to "Pending"
            _orderService.SetOrderStatus(order, "Pending");

            // Create the order
            var createdOrder = await _orderService.CreateOrderAsync(order);
            if (createdOrder == null)
            {
                return NotFound();
            }

            // Return a simplified response
            var createdOrderDto = new OrderDto
            {
                Id = createdOrder.Id,
                OrderDate = createdOrder.OrderDate,
                OrderItems = createdOrder.OrderRows.SelectMany(or => or.MenuItem).Select(mi => new OrderProductDto
                {
                    ProductId = mi.Id,
                    Quantity = 1 // Set a default quantity (you can adjust as needed)
                }).ToList()
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
