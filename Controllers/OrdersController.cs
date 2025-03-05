using API_CoffeQ.DTOs;
using API_CoffeQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_CoffeQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrdersController(IOrderRepository orderRepository): ControllerBase
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

    

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            var order = await _orderRepository.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("Customer/{customerid}")]
        public async Task<ActionResult<List<OrderDTO>>> GetOrders(int customerid)
        {
            var orders = await _orderRepository.GetOrders(customerid);
            return Ok(orders);
        }
        [HttpGet("Record/{user}")]
        public async Task<ActionResult<OrderDTO>> GetRecordOrder(string user)
        {
            var order = await _orderRepository.ClientOrderRecord(user);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder(OrderDTO order)
        {
            var newOrder = await _orderRepository.AddOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.IdOrder }, newOrder);
        }
        [HttpPost("Detail/{orderid}")]
        public async Task<ActionResult<OrderDetailDTO>> AddOrderDetail(OrderDetailDTO order)
        {
            var newOrder = await _orderRepository.AddOrderDetail(order);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.IdOrder }, newOrder);
        }

        [HttpPut]
        public async Task<ActionResult<OrderDTO>> UpdateOrder(OrderDTO order)
        {
            var newOrder = await _orderRepository.UpdateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = newOrder.IdOrder }, newOrder);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDTO>> DeleteOrder(int id)
        {
            var order = await _orderRepository.DeleteOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
    }
}
