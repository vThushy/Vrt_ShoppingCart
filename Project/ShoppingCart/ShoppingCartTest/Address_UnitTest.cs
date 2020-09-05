using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShoppingCart.Contracts;
using ShoppingCart.Controllers;
using ShoppingCart.Models;
using System.Collections.Generic;
using Xunit;

namespace ShoppingCartTest
{
    public class Address_UnitTest
    {
        private Mock<IAddressRepository> _userRepository;
        AddressController _controller;
        private Address InsertAddress;

        public Address_UnitTest()
        {
            _userRepository = new Mock<IAddressRepository>();
            InsertAddress = new Address()
            {
                UserName = "vThushy",
                AddressType = "Work",
                AddressLine = "Danister silva mw",
                City = "Dematagoda",
                State = "Western",
                Country = "Sri Lanka",
                ZipCode = "17000"
            };
        }

        private List<Address> SetDataForTest()
        {
            var _logger = Mock.Of<ILogger<AddressController>>(); 

            var addresses = new List<Address>();
            addresses.Add(new Address()
            {
                Id = 1,
                UserName = "vThushy",
                AddressType = "Home",
                AddressLine = "Kachchceri Road",
                City = "Jaffna",
                State = "Northern",
                Country = "Sri Lanka",
                ZipCode = "40000"
            });
            addresses.Add(new Address()
            {
                Id = 2,
                UserName = "vThushy",
                AddressType = "Work",
                AddressLine = "Danister silva mw",
                City = "Dematagoda",
                State = "Western",
                Country = "Sri Lanka",
                ZipCode = "17000"
            });

            return addresses;
        }

        [Fact]
        public void Test_InsertAddressAndReturnOk()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();
            _userRepository.Setup(r => r.AddAddress(InsertAddress));
            _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.AddAddress(InsertAddress);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Test_InsertAddressAndReturn()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();
            _userRepository.Setup(r => r.AddAddress(InsertAddress));
            AddressController _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.AddAddress(InsertAddress);
            OkObjectResult okObjectResult = result as OkObjectResult;
            Address returnResult = okObjectResult.Value as Address;
            Assert.Equal(InsertAddress.UserName, returnResult.UserName);
        }

        [Fact]
        public void Test_ReturnAddresses_WhenAddressFound()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();

            _userRepository.Setup(r => r.GetAddressesByUser("vThushy")).Returns(SetDataForTest());
            _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.GetAllAddressByCustomer("vThushy");
            OkObjectResult okObjectResult = result as OkObjectResult;
            List<Address> resturnResult = okObjectResult.Value as List<Address>;
            Assert.Equal(2, resturnResult.Count);
        }

        [Fact]
        public void Test_ReturnOk_WhenAddressFound()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();

            _userRepository.Setup(r => r.GetAddressesByUser("vThushy")).Returns(SetDataForTest());
            _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.GetAllAddressByCustomer("vThushy");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Test_Return0Address_WhenAddressNotFound()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();
            List<Address> emptyAddress = new List<Address>();
            _userRepository.Setup(r => r.GetAddressesByUser("vThushy")).Returns(emptyAddress);
            _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.GetAllAddressByCustomer("vThushy");
            OkObjectResult okObjectResult = result as OkObjectResult;
            List<Address> resturnResult = okObjectResult.Value as List<Address>;
            Assert.Empty(resturnResult);
        }

    }
}
