using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{

    [ApiController]
    [Route("cart")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartRepository cartRepository;

        public CartController(ICartRepository _cartRepository, ILogger<CartController> logger)
        {
            _logger = logger;
            cartRepository = _cartRepository;
        }

        [HttpGet("{customerId}")]
        public IActionResult GetCartItems(int customerId)
        {
            int orderId = cartRepository.GetOrderId(customerId);
            if (orderId > 0)
            {
                return Ok(cartRepository.GetOrderDetails(orderId));
            }
            return BadRequest("Cart items not found.");
        }

    }
}
