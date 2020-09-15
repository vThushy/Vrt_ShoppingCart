using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Enum;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("payment")]
    [Authorize]
    public class PaymentController : Controller
    {
        #region Class variables
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        #endregion

        #region Constructor
        public PaymentController(IPaymentRepository paymentRepository, IOrderRepository orderRepository, 
            ILogger<PaymentController> logger, IProductRepository productRepository, IOrderDetailsRepository orderDetailsRepository)
        {
            _logger = logger;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }
        #endregion

        #region Methods

        [HttpGet("userName")]
        public IActionResult GetPaymentsByUser(string userName)
        {
            try
            {
                if (userName != null)
                {
                    List<Payment> payments = _paymentRepository.GetPaymentsByUser(userName);
                    return Ok(payments);
                }
                return BadRequest("Payment is null.");
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: " + e);
                return Problem(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult MakePayment([FromBody] Payment payment)
        {
            try
            {
                if (payment != null)
                {
                    if (_paymentRepository.MakeAPayment(payment))
                    {
                        _orderRepository.OrderStatusChanged(payment.OrderId, OrderStatus.Paid);
                        List<OrderDetail> lines = _orderDetailsRepository.GetOrderLines(payment.OrderId);
                        _productRepository.ReduceStock(payment.OrderId,lines);
                        return Ok("Payment made.");
                    }
                    return Ok("Payment not made.");
                }
                return BadRequest("Payment is null.");
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: " + e);
                return Problem(e.ToString());
            }
        }
        #endregion
    }
}
