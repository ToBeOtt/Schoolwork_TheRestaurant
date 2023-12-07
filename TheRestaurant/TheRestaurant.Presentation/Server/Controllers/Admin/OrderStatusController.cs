using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheRestaurant.Application.Interfaces.IOrderStatus;
using TheRestaurant.Contracts.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheRestaurant.Presentation.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }


        // GET: api/OrderStatus
        [HttpGet]
        public async Task<ActionResult<List<OrderStatusDto>>> GetAllOrderStatus()
        {
            var listOrderStatusDto = await _orderStatusService.GetAllAsync();
            if (listOrderStatusDto.Count == 0)
            {
                return NotFound();
            };
            return Ok(listOrderStatusDto);
        }

        // GET api/OrderStatus/2
        [HttpGet("{id}", Name = "GetOrderStatus")]
        public async Task<ActionResult<OrderStatusDto>> GetOrderStatus(int id)
        {
            var listOrderStatusDto = await _orderStatusService.GetAllAsync();
            if (listOrderStatusDto.Count == 0)
            {
                return NotFound();
            };

            var orderStatusDto = await _orderStatusService.GetAsync(id);
            if (orderStatusDto == null)
            {
                return NotFound();
            };
            return Ok(orderStatusDto);
        }

        // POST api/OrderStatus
        [HttpPost]
        public async Task<ActionResult<OrderStatusDto>> PostOrderStatus([FromBody] OrderStatusDto orderStatusDto)
        {
            //orderStatusDto.IsDeleted = false;

            bool IsAdded = await _orderStatusService.AddAsync(orderStatusDto);

            if (IsAdded)
            {
                return CreatedAtAction("GetOrderStatus", new { id = orderStatusDto.Id }, orderStatusDto);
            }
            else
                return NotFound();
        }

        // PUT api/OrderStatus/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutOrderStatus(int id, [FromBody] OrderStatusDto orderStatusDto)
        {
            if (id != orderStatusDto.Id)
            {
                return BadRequest();
            }

            try
            {
                await _orderStatusService.UpdateAsync(orderStatusDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_orderStatusService.Equals(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(200, $"Status {orderStatusDto.Status} Updated!");
        }

        // DELETE api/OrderStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var listOrderStatus = await _orderStatusService.GetAllAsync();
            var orderStatusDto = await _orderStatusService.GetAsync(id);
            if (listOrderStatus == null || orderStatusDto == null)
            {
                return NotFound();
            };

            await _orderStatusService.DeleteAsync(id);
            //return NoContent();
            return StatusCode(200, $"Status {orderStatusDto.Status} Deleted!");
        }
     
    }
}
