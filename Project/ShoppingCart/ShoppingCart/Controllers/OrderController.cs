
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Enum;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        #region class variables
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        #endregion

        #region constructor
        public OrderController(IOrderRepository orderRepository, IOrderDetailsRepository orderDetailsRepository, ILogger<OrderController> logger)
        {
            _orderRepository = orderRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _logger = logger;
        }
        #endregion

        #region methods

        [HttpGet("customer/{userName}")]
        public IActionResult GetAllOrdersByCustomer(string userName)
        {
            try
            {
                List<Order> orders = _orderRepository.GetAllOrdersByCustomer(userName);
                List<OrderWithDetails> returnOrders = new List<OrderWithDetails>();

                foreach (Order order in orders)
                {
                    if (order != null)
                    {
                        OrderWithDetails o = new OrderWithDetails();
                        o.order = order;
                        List<OrderDetail> orderDetail = _orderDetailsRepository.GetOrderLines(order.Id);
                        o.orderLines= orderDetail;
                        returnOrders.Add(o);
                    }
                }
                
                return Ok(returnOrders);
            }
            catch (SqlException e)
            {
                _logger.LogError(e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpGet("active/{userName}")]
        public IActionResult GetActiveOrdersByCustomer(string userName)
        {
            try
            {
                List<Order> orders = _orderRepository.GetActiveOrder(userName);
                List<OrderWithDetails> returnOrders = new List<OrderWithDetails>();

                foreach (Order order in orders)
                {
                    if (order != null)
                    {
                        OrderWithDetails o = new OrderWithDetails();
                        o.order = order;
                        List<OrderDetail> orderDetail = _orderDetailsRepository.GetOrderLines(order.Id);
                        o.orderLines = orderDetail;
                        returnOrders.Add(o);
                    }
                }

                return Ok(returnOrders);
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
                OrderWithDetails order = new OrderWithDetails();
                order.order = _orderRepository.GetOrder(id);

                if (order.order != null)
                {
                    var orderLines = _orderDetailsRepository.GetOrderLines(id);
                    order.orderLines = orderLines;
                    return Ok(order);

                }
                return NotFound("Order not exist");
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Order Controller: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderWithDetails order)
        {
            try
            {
                if (order != null)
                {
                    int orderId = _orderRepository.AddOrder(order.order);
                    foreach (OrderDetail o in order.orderLines)
                    {
                        o.OrderId = orderId;
                        _orderDetailsRepository.AddOrderLine(o);
                    }
                    return Ok(orderId);
                }
                return BadRequest();
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
