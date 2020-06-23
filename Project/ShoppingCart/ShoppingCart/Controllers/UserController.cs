using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using ShoppingCart.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController: ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository, ILogger<ProductController> logger)
        {
            _logger = logger;
            userRepository = _userRepository;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Product is null.");
            }

            userRepository.AddUser(user);
            return Ok("User added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null.");
            }

            //User productToUpdate = userRepository.GetProduct(id);
            //if (productToUpdate == null)
            //{
            //    return NotFound("The product not found!");
            //}

            //productRepository.ModifyProduct(productToUpdate, product);
            return NoContent();
        }


    }
}
