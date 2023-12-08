using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using TheRestaurant.Application.Interfaces;
using TheRestaurant.Application.Orders;
using TheRestaurant.Contracts.Requests.Order;
using TheRestaurant.Presentation.Shared.DTO.Orders;
using TheRestaurant.Presentation.Shared.Requests.Order;
namespace TheRestaurant.Presentation.Server.Controllers.Order
{
    [Route("Order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("GetCustomerOrder")]
        public async Task<ActionResult> GetCustomerOrder(int id)
        {
            var result = await _orderService.GetCustomerOrder(id);
            if (! result.IsSuccess)
            {
                return BadRequest();
            }
            
            return Ok(result.Data);
        }


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
                return Ok(result.Data);
        }


        [HttpGet("{status}")]
        public async Task<ActionResult<List<Domain.Entities.Orders.Order>>> GetOrdersByStatus(string status)
        {
            var orders = await _orderService.GetOrderByOrderStatus(status);

            if(orders.Count is 0)
            {
                return Ok($"Inga order med status:{status} kunde hittas");
            }

            return Ok(orders);
        }

        [HttpDelete("CancelOrder/{id}")]
        public async Task<ActionResult> CancelOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }


        [HttpGet("FetchAllActiveOrders")]
        public async Task<ActionResult> FetchAllActiveOrders()
        {
            var result = await _orderService.GetListOfActiveOrders();
            if (!result.IsSuccess)
            {
                return BadRequest();
            }

            return Ok(result.Data);
        }

    }
}