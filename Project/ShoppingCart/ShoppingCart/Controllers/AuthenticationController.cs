using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;
using ShoppingCart.Contracts;
using ShoppingCart.Utility;
using System;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> logger;
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public AuthenticationController(IUserRepository _userRepository, ILogger<AuthenticationController> _logger,
            IConfiguration _configuration)
        {
            logger = _logger;
            userRepository = _userRepository;
            configuration = _configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var verifyUser = userRepository.VerifyUser(user);

            if (user != null)
            {
                Token token = new Token(configuration);
                var tokenString = token.GenerateJSONWebToken(verifyUser);
                logger.LogInformation($"User {user.UserName} login on {DateTime.UtcNow.ToLongTimeString()}");
                return Ok(new { token = tokenString });
            }

            return BadRequest("Wrong username or password!");
        }
    }
}
