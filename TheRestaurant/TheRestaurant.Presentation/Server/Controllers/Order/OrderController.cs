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
                Comment = null,
                Id = order.Id,
                OrderDate = order.OrderDate
            };

            return orderDto;
        }
        [HttpPost("createOrder")]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto orderDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"");
                    return BadRequest(ModelState);
                }


                var createOrderRequest = new CreateOrderRequest
                {
                    OrderDate = orderDto.OrderDate,
                    OrderItems = orderDto.CartItems.Select(item => new OrderProductDto
                    {
                        Id = item.Id,
                        Count = item.Count,
                        Name = item.Name,
                        Price = item.Price
                    }).ToList()
                };

                var order = new Domain.Entities.OrderEntities.Order
                {
                    OrderDate = orderDto.OrderDate,
                    OrderRows = new List<OrderRow>()
                };

                foreach (var orderItemDto in orderDto.CartItems)
                {
                    // You don't need to create detailed product entities here,
                    // only include the ProductId and Quantity
                    // Include the ProductId and Quantity
                    var product =
                new Domain.Entities.Menu.Product
                {
                    Id = orderItemDto.Id,
                    Name = "Product Name",
                    Price = 0,
                    IsFoodItem = false,
                    IsDeleted = false
                };
                    var orderRow = new OrderRow(product, order);
                };

                // Set the status of the order to "Pending"
                _orderService.SetOrderStatus(order, "Pending");

                // Create the order
                var createdOrder = await _orderService.CreateOrderAsync(order);
                if (createdOrder == null)
                {
                    // Return a 500 Internal Server Error response if creation fails
                    return StatusCode(500, "Failed to create the order.");
                }

                // Return a simplified response
                //var createdOrderDto = new OrderDto
                //{
                //    Id = createdOrder.Id,
                //    OrderDate = createdOrder.OrderDate,
                //    CartItems = createdOrder.OrderRows
                //    .SelectMany(or => or.Product)
                //    .Select(mi => new OrderProductDto
                //    {
                //        Id = mi.Id,
                //        Price = mi.Price,
                //        Name = mi.Name
                //    }).ToList()
                //};

                return Ok(orderDto);
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                

                // Return a 500 Internal Server Error response for unhandled exceptions
                return StatusCode(500, "An error occurred during order creation.");
            }
        }



        private readonly IOrderService _orderService;

        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }
    }

}
