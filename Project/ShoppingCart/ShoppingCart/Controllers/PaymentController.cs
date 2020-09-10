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
        #endregion

        #region Constructor
        public PaymentController(IPaymentRepository paymentRepository, IOrderRepository orderRepository, ILogger<PaymentController> logger)
        {
            _logger = logger;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
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
                    _paymentRepository.MakeAPayment(payment);
                    _orderRepository.OrderStatusChanged(payment.OrderId, OrderStatus.Paid);
                    return Ok("Payment made.");
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
