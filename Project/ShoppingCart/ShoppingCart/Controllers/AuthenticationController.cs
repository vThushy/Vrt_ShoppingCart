using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;
using ShoppingCart.Contracts;
using ShoppingCart.Utility;
using System;
using System.Net;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        #region class variables
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _configuration;
        #endregion

        #region constructor
        public AuthenticationController(
            IUserRepository userRepository,
            ILogger<AuthenticationController> logger,
            ICustomerRepository customerRepository,
            IConfiguration configuration)
        {
            _logger = logger;
            _userRepository = userRepository;
            _configuration = configuration;
            _customerRepository = customerRepository;
        }
        #endregion

        #region methods

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                var verifyUser = _userRepository.VerifyUser(user);

                if (verifyUser != null)
                {
                    Token token = new Token(_configuration);
                    var tokenString = token.GenerateJSONWebToken(verifyUser);
                    _logger.LogInformation($"User {verifyUser.UserName} login on {DateTime.UtcNow.ToLongTimeString()}");
                    return Ok(new { customerId = verifyUser.UserName, token = tokenString });
                }

                return Ok("Wrong user name or password!");
            }
            catch (Exception e)
            {
                _logger.LogError("Error in authentication controller: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        #endregion
    }
}
