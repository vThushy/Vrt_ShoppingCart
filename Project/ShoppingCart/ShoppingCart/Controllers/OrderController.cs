
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        #region class variables
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _orderRepository;
        #endregion

        #region constructor
        public OrderController(IOrderRepository orderRepository, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        #endregion

        #region methods

        [HttpGet("customer/{userName}")]
        public IActionResult GetAllOrdersByCustomer(string userName)
        {
            try
            {
                var response = _orderRepository.GetAllOrdersByCustomer(userName);
                return Ok(response);
            }
            catch (SqlException e)
            {
                _logger.LogError(e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            try
            {
                var response = _orderRepository.GetOrder(id);
                if (response == null)
                {
                    return NotFound("Order not exist");
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Order Controller: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Order is null");
                }
                _orderRepository.AddOrder(order);
                return CreatedAtAction("Get", new { id = order.Id }, order);
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Product controller: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModifyOrder(int id, [FromBody] Order order)
        {
            try
            {
                if (order != null && id > 0)
                {

                    _orderRepository.ModifyOrder(id, order);
                    return NoContent();
                }
                else
                {
                    return BadRequest("Wrong request!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Product controller: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveOrder(int id)
        {
            try
            {
                Order orderToDelete = _orderRepository.GetOrder(id);
                if (orderToDelete == null)
                {
                    return NotFound("The order not found!");
                }
                // _orderRepository.RemoveOrder(orderToDelete);
                _logger.LogInformation($"Order {orderToDelete.Id} deleted on {DateTime.UtcNow.ToLongTimeString()}");
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Product controller: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        #endregion
    }
}
