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
        private readonly IConfiguration _configuration;
        #endregion

        #region constructor
        public AuthenticationController(
            IUserRepository userRepository,
            ILogger<AuthenticationController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _userRepository = userRepository;
            _configuration = configuration;
        }
        #endregion

        #region methods

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                bool verifiedUser = _userRepository.VerifyUser(user);

                if (verifiedUser)
                {
                    Token token = new Token(_configuration);
                    var tokenString = token.GenerateJSONWebToken();
                    _logger.LogInformation($"User {user.UserName} login on {DateTime.UtcNow.ToLongTimeString()}");
                    return Ok(new { customerId = user.UserName, token = tokenString });
                }

                return Ok(new { customerId = "", token = "" });
            }
            catch (Exception e)
            {
                _logger.LogError("Error in authentication controller: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpGet("{userName}")]
        public IActionResult ValidateUserName(string userName)
        {
            try
            {
                if (_userRepository.ValidUserName(userName))
                {
                    return Ok(true);
                }
                return Ok(false);
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
