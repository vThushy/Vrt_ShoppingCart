


using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    [Authorize]
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> logger;
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository _orderRepository, ILogger<OrderController> _logger)
        {
            orderRepository = _orderRepository;
            logger = _logger;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var response = orderRepository.GetAllOrders();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var response = orderRepository.GetOrder(id);
            if (response == null)
            {
                return NotFound("Order not exist");
            }
            return Ok(response);
        }

        public IActionResult AddOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order is null");
            }
            orderRepository.AddOrder(order);
            return CreatedAtAction("Get", new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult ModifyOrder(int id, [FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Order is null.");
            }

            Order orderToUpdate = orderRepository.GetOrder(id);
            if (orderToUpdate == null)
            {
                return NotFound("The order not found!");
            }

            orderRepository.ModifyOrder(orderToUpdate, order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveOrder(int id)
        {
            Order orderToDelete = orderRepository.GetOrder(id);
            if (orderToDelete == null)
            {
                return NotFound("The order not found!");
            }
            orderRepository.RemoveOrder(orderToDelete);
            logger.LogInformation($"Order {orderToDelete.Id} deleted on {DateTime.UtcNow.ToLongTimeString()}");
            return NoContent();
        }

    }
}
