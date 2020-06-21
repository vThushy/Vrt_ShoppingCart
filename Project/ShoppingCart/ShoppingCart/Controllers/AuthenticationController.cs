using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Models;
using ShoppingCart.Models.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("authentication")]
    public class AuthenticationController: ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private IConfiguration configuration;
        private readonly IUserRepository userRepository;

        public AuthenticationController(IUserRepository _userRepository, ILogger<ProductController> _logger,
            IConfiguration _configuration)
        {
            logger = _logger;
            configuration = _configuration;
            userRepository = _userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            //IActionResult response = Unauthorized();
            IActionResult response = null;
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                return Ok(new { token = tokenString });
            }

            return response;
        }

        //private IActionResult Unauthorized()
        //{
        //    throw new NotImplementedException();
        //}

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
              configuration["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User user)
        {
            return userRepository.VerifyUser(user);
            
            ////Validate the User Credentials    
            ////Demo Purpose, I have Passed HardCoded User Information    
            //if (login.UserName == "Jignesh")
            //{
            //    user = new UserModel { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };
            //}
            //return user;
        }
    }
}
