using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using ShoppingCart.Contracts;
using ShoppingCart.Controllers;
using ShoppingCart.Models;
using ShoppingCart.Utility;
using System;
using Xunit;

namespace ShoppingCartTest
{
    public class Customer_UnitTest
    {
        private Mock<ICustomerRepository> _customerRepository;
        private Mock<IUserRepository> _userRepository;
        private Mock<IAddressRepository> _addressRepository;
        private CustomerController _controller;
        private Mock<IConfiguration> _configuration;

        public Customer_UnitTest()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _userRepository = new Mock<IUserRepository>();
            _addressRepository = new Mock<IAddressRepository>();
            _configuration = new Mock<IConfiguration>();
        }

        [Fact]
        public void Test_InsertCustomerAndReturnOk()
        {
            var _logger = Mock.Of<ILogger<CustomerController>>();

            Datas data = new Datas();
            _customerRepository.Setup(c => c.AddCustomer(data.SetCustomerForTest));
            _userRepository.Setup(u => u.AddUser(data.SetUserForTest));
            _addressRepository.Setup(a => a.AddAddress(data.SetAddressForTest));
            var validApiKey = "";
            Action action = () => new Token(_configuration.Object);

            _configuration
               .SetupGet(c => c["Jwt:Key"])
               .Returns(validApiKey); 

            _controller = new CustomerController(_customerRepository.Object, _userRepository.Object, _addressRepository.Object, _logger, _configuration.Object);

            IActionResult result = _controller.AddCustomer(data.SetCustomerRegObjForTest);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Test_ReturnResponseUser()
        {
            var _logger = Mock.Of<ILogger<CustomerController>>();

            Datas data = new Datas();
            _customerRepository.Setup(c => c.AddCustomer(data.SetCustomerForTest));
            _userRepository.Setup(u => u.AddUser(data.SetUserForTest));
            _addressRepository.Setup(a => a.AddAddress(data.SetAddressForTest));

            _controller = new CustomerController(_customerRepository.Object, _userRepository.Object, _addressRepository.Object, _logger, _configuration.Object);
           
            IActionResult result = _controller.AddCustomer(data.SetCustomerRegObjForTest);
          //  Assert.IsType<OkObjectResult>(result);
          //  IActionResult result = _controller.AddAddress(datas.SetAddressForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            ResponseUser returnResult = okObjectResult.Value as ResponseUser;
            Assert.Equal(data.SetResponseUserForTest.customerId, returnResult.customerId);
            Assert.Equal(data.SetResponseUserForTest.token, returnResult.token);
        }


    }
}
