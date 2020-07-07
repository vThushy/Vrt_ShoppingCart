using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController: ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository, ILogger<UserController> _logger)
        {
            logger = _logger;
            userRepository = _userRepository;
        }

        [HttpPut("{id}")]
        public IActionResult ChangePassword([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            User userToBeUpdate = userRepository.GetUser(user.UserName);
            if (userToBeUpdate == null)
            {
                return NotFound("The product not found!");
            }

            userRepository.ChangePassword(userToBeUpdate);
            return NoContent();
        }


    }
}
