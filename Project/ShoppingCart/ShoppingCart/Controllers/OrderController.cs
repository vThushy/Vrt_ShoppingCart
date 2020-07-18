
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
            try
            {
                var response = orderRepository.GetAllOrders();
                return Ok(response);
            }
            catch(Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
            var response = orderRepository.GetOrder(id);
            if (response == null)
            {
                return NotFound("Order not exist");
            }
            return Ok(response);
            }
            catch(Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        public IActionResult AddOrder([FromBody] Order order)
        {
            try
            {
            if (order == null)
            {
                return BadRequest("Order is null");
            }
            orderRepository.AddOrder(order);
            return CreatedAtAction("Get", new { id = order.Id }, order);
            }
            catch(Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModifyOrder(int id, [FromBody] Order order)
        {
            try
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
            catch (Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveOrder(int id)
        {
            try
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
            catch (Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

    }
}
