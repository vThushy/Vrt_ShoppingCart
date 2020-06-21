using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class UserController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository, ILogger<ProductController> logger)
        {
            _logger = logger;
            userRepository = _userRepository;
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] User user)
        //{
        ////    bool response = userRepository.VerifyUser(user);
        ////    if (response)
        ////    {
        ////        return BadRequest("Product is null.");
        ////    }
        ////    return BadRequest("Product is null.");
        //}

        
    }
}
