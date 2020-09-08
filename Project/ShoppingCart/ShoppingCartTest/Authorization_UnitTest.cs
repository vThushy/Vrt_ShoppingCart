using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using ShoppingCart.Contracts;
using ShoppingCart.Controllers;
using ShoppingCart.Models;
using Xunit;

namespace ShoppingCartTest
{
    public class Authorization_UnitTest
    {
        private AuthenticationController _controller;
        Mock<IUserRepository> _userRepository;

        public Authorization_UnitTest()
        {
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public void Should_Return200Ok_When_Login_WithCorrectCredentials()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();
            
            _userRepository.Setup(r => r.VerifyUser(data.SetUserForTest)).Returns(true);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.Login(data.SetUserForTest);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Should_ReturnUser_When_Login_WithCorrectCredentials()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();

            _userRepository.Setup(r => r.VerifyUser(data.SetUserForTest)).Returns(true);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.Login(data.SetUserForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            var val = okObjectResult.Value;
            Assert.IsType<ResponseUser>(val);
        }


        [Fact]
        public void Should_Return200Ok_When_Login_WithWrongCredentials()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();

            _userRepository.Setup(r => r.VerifyUser(data.SetUserForTest)).Returns(false);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.Login(data.SetUserForTest);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Should_ReturnUserType_When_Login_WithWrongCredentials()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();

            _userRepository.Setup(r => r.VerifyUser(data.SetUserForTest)).Returns(true);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.Login(data.SetUserForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            var val = okObjectResult.Value;
            Assert.IsType<ResponseUser>(val);
        }

        [Fact]
        public void Should_ReturnEmptyUserName_When_Login_WithWrongCredentials()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();

            _userRepository.Setup(r => r.VerifyUser(data.SetUserForTest)).Returns(true);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.Login(data.SetUserForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            var val = okObjectResult.Value as ResponseUser;
            Assert.Equal("", val.customerId);
        }

        [Fact]
        public void Should_ReturnEmptyUserToken_When_Login_WithWrongCredentials()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();

            _userRepository.Setup(r => r.VerifyUser(data.SetUserForTest)).Returns(true);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.Login(data.SetUserForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            var val = okObjectResult.Value as ResponseUser;
            Assert.Equal("", val.token);
        }

        [Fact]
        public void Should_Return200Ok_When_ValidateUserName_WithValidUserName()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();

            _userRepository.Setup(r => r.ValidUserName(data.SetUserNameForTest)).Returns(true);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.ValidateUserName(data.SetUserNameForTest);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Should_ReturnTrue_When_ValidateUserName_WithValidUserName()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();

            _userRepository.Setup(r => r.ValidUserName(data.SetUserNameForTest)).Returns(true);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.ValidateUserName(data.SetUserNameForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            var val = okObjectResult.Value;
            Assert.Equal(true, val);
        }

        [Fact]
        public void Should_Return200Ok_When_ValidateUserName_WithWrongUserName()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();

            _userRepository.Setup(r => r.ValidUserName(data.SetUserNameForTest)).Returns(false);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.ValidateUserName(data.SetUserNameForTest);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Should_ReturnTrue_When_ValidateUserName_WithWrongUserName()
        {
            var _logger = Mock.Of<ILogger<AuthenticationController>>();
            var _configuration = Mock.Of<IConfiguration>();
            Datas data = new Datas();

            _userRepository.Setup(r => r.ValidUserName(data.SetUserNameForTest)).Returns(false);
            _controller = new AuthenticationController(_userRepository.Object, _logger, _configuration);

            IActionResult result = _controller.ValidateUserName(data.SetUserNameForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            var val = okObjectResult.Value;
            Assert.Equal(false, val);
        }

    }
}
