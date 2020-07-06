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

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }
            userRepository.AddUser(user);
            logger.LogInformation($"User {user.UserName} added on {DateTime.UtcNow.ToLongTimeString()}");
            return Ok("User added");
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] User user)
        ////{
        ////    if (user == null)
        ////    {
        ////        return BadRequest("User is null.");
        ////    }

        ////    User productToUpdate = userRepository.GetProduct(id);
        ////    if (productToUpdate == null)
        ////    {
        ////        return NotFound("The product not found!");
        ////    }

        ////    productRepository.ModifyProduct(productToUpdate, product);
        ////    return NoContent();
        ////}


    }
}
