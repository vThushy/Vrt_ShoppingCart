using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;
using ShoppingCart.Contracts;
using ShoppingCart.Utility;
using System;
using ShoppingCart.Repository;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> logger;
        private readonly IUserRepository userRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IConfiguration configuration;

        public AuthenticationController(
            IUserRepository _userRepository, 
            ILogger<AuthenticationController> _logger,
            ICustomerRepository _customerRepository,
            IConfiguration _configuration)
        {
            logger = _logger;
            userRepository = _userRepository;
            configuration = _configuration;
            customerRepository = _customerRepository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
            var verifyUser = userRepository.VerifyUser(user);

            if (verifyUser != null)
            {
                Token token = new Token(configuration);
                var tokenString = token.GenerateJSONWebToken(verifyUser);
                int userId = customerRepository.GetCustomerId(verifyUser.UserName);
                logger.LogInformation($"User {user.UserName} login on {DateTime.UtcNow.ToLongTimeString()}");
                return Ok(new { customerId = userId, token = tokenString });
            }

            return BadRequest("Wrong username or password!");
            }
            catch (Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }
    }
}
