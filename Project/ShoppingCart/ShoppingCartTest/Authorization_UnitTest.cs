using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Controllers;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace ShoppingCartTest
{
    public class Authorization_UnitTest
    {
        private AuthenticationController _controller;

        public Authorization_UnitTest()
        {
            var _userRepository = new Mock<IUserRepository>();
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();

            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);
        }

        [Fact]
        public void TestAuthenticationApiReturnOkResult()
        {
            User user = new User();
            user.UserName = "Thushy";
            user.Password = "Thushy";

            var okResult = _controller.Login(user);

            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
