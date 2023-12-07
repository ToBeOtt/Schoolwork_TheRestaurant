using Microsoft.AspNetCore.Mvc;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Application.Orders;
using TheRestaurant.Contracts.Requests.Order;
using TheRestaurant.Presentation.Shared.Requests.Order;
namespace TheRestaurant.Presentation.Server.Controllers.Order
{
    [Route("Order")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly OrderService _orderService;

        public ProductController(OrderService orderService)
        {
            _orderService = orderService;
        }
        //[HttpGet("{id}")]
        //public async Task<ActionResult<OrderDto>> GetOrder(int id)
        //{
        //    var order = await _orderService.GetOrderByIdAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    var orderDto = new OrderDto
        //    {
        //        Id = order.Id,
        //        OrderDate = order.OrderDate
        //    };
        //    return orderDto;
        //}

        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder([FromBody] PlaceOrderRequest request)
        {
            CreateOrderRequest createOrderRequest = new();

            if (request.Comment != null)
                createOrderRequest.Comment = request.Comment;

            foreach (var item in request.ListOfAggregatedIds)
            {
                ProductAggregateForCreateOrder productAggregate =
                    new(item.Count, item.IdOfOrderAggregate);
                createOrderRequest.ProductAggregate.Add(productAggregate);
            }

            var result = await _orderService.CreateOrderAsync(createOrderRequest);

            if(! result.IsSuccess)
                return BadRequest(result.Data);

            else
                return Ok(result);
        }
    }
}