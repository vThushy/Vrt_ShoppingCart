using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        #region class variables
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;
        #endregion

        #region construtor
        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        #endregion

        #region methods
        [HttpGet("{userName}")]
        public IActionResult ForgotPassword(string userName)
        {
            try
            {
                _userRepository.SendResetCode(userName);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult ValidateResetCode([FromBody] ResetReq resetReq)
        {
            try
            {
                if (resetReq != null)
                {
                    bool isValid = _userRepository.ValidateResetCode(resetReq.UserName, resetReq.ResetCode);
                    if (isValid)
                    {
                        return Ok();
                    }
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpPut]
        public IActionResult ChangePassword([FromBody] User user)
        {
            try
            {
                if (user != null)
                {
                    _userRepository.ChangePassword(user);
                    return Ok("Password changed");
                }
                return BadRequest("User is null.");
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }

        }
        #endregion
    }

    public class ResetReq
    {
        public string UserName { get; set; }
        public string ResetCode { get; set; }
    }
}
