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

        public Address_UnitTest()
        {
            _userRepository = new Mock<IAddressRepository>();
        }


        [Fact]
        public void Test_InsertAddressAndReturnOk()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();
            Datas data = new Datas();
            _userRepository.Setup(r => r.AddAddress(data.SetAddressForTest));
            _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.AddAddress(data.SetAddressForTest);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Test_InsertAddressAndReturn()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();
            Datas datas = new Datas();
            _userRepository.Setup(r => r.AddAddress(datas.SetAddressForTest));
            AddressController _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.AddAddress(datas.SetAddressForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            Address returnResult = okObjectResult.Value as Address;
            Assert.Equal(datas.SetAddressForTest.Id, returnResult.Id);
            Assert.Equal(datas.SetAddressForTest.UserName, returnResult.UserName);
            Assert.Equal(datas.SetAddressForTest.AddressLine, returnResult.AddressLine);
            Assert.Equal(datas.SetAddressForTest.AddressType, returnResult.AddressType);
            Assert.Equal(datas.SetAddressForTest.City, returnResult.City);
            Assert.Equal(datas.SetAddressForTest.State, returnResult.State);
            Assert.Equal(datas.SetAddressForTest.ZipCode, returnResult.ZipCode);
            Assert.Equal(datas.SetAddressForTest.Country, returnResult.Country);
        }

        [Fact]
        public void Test_ReturnAddresses_WhenAddressFound()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();
            Datas datas = new Datas();

            _userRepository.Setup(r => r.GetAddressesByUser("vThushy")).Returns(datas.SetListOfAddressForTest);
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
            Datas datas = new Datas();
            _userRepository.Setup(r => r.GetAddressesByUser("vThushy")).Returns(datas.SetListOfAddressForTest);
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

        [Fact]
        public void Test_ReturnOk_WhenAddressDelete()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();
            List<Address> emptyAddress = new List<Address>();
            _userRepository.Setup(r => r.RemoveAddress(1)).Returns(true);
            _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.RemoveAddress(1);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Test_ReturnOk_WhenAddressFoundById()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();
            Datas datas = new Datas();
            _userRepository.Setup(r => r.GetAddress(1)).Returns(datas.SetAddressForTest);
            _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.GetAddressById(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Test_ReturnAddress_WhenAddressFoundById()
        {
            var _logger = Mock.Of<ILogger<AddressController>>();
            Datas datas = new Datas();
            _userRepository.Setup(r => r.GetAddress(1)).Returns(datas.SetAddressForTest);
            _controller = new AddressController(_logger, _userRepository.Object);

            IActionResult result = _controller.GetAddressById(1);
            OkObjectResult okObjectResult = result as OkObjectResult;
            Address resturnResult = okObjectResult.Value as Address;
            Assert.Equal(datas.SetAddressForTest.Id, resturnResult.Id);
            Assert.Equal(datas.SetAddressForTest.UserName, resturnResult.UserName);
            Assert.Equal(datas.SetAddressForTest.AddressLine, resturnResult.AddressLine);
            Assert.Equal(datas.SetAddressForTest.AddressType, resturnResult.AddressType);
            Assert.Equal(datas.SetAddressForTest.City, resturnResult.City);
            Assert.Equal(datas.SetAddressForTest.State, resturnResult.State);
            Assert.Equal(datas.SetAddressForTest.ZipCode, resturnResult.ZipCode);
            Assert.Equal(datas.SetAddressForTest.Country, resturnResult.Country);

        }
    }
}
