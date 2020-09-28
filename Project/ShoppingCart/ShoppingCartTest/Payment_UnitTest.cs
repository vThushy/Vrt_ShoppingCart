using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ShoppingCart.Contracts;
using ShoppingCart.Controllers;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppingCartTest
{
    public class Payment_UnitTest
    {
        #region config
        private Mock<IPaymentRepository> _paymentRepository;
        private Mock<IOrderRepository> _orderRepository;
        private Mock<IOrderDetailsRepository> _orderDetailsRepository;
        private Mock<IProductRepository> _productRepository;
        private PaymentController _controller;
        private Datas datas;

        public Payment_UnitTest()
        {
            _paymentRepository = new Mock<IPaymentRepository>();
            _orderRepository = new Mock<IOrderRepository>();
            _orderDetailsRepository = new Mock<IOrderDetailsRepository>();
            _productRepository = new Mock<IProductRepository>(); 
            datas = new Datas();
        }
        #endregion

        #region Tests - GetPaymentsByUser
        [Fact]
        public void Should_Return200Ok_When_GetPaymentsByUser_PaymentsFound()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.GetPaymentsByUser("Thushy")).Returns(datas.SetListPaymentForTest);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.GetPaymentsByUser("Thushy");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Should_ReturnPaymentType_When_GetPaymentsByUser_PaymentsFound()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.GetPaymentsByUser("Thushy")).Returns(datas.SetListPaymentForTest);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.GetPaymentsByUser("Thushy");
            OkObjectResult okObjectResult = result as OkObjectResult;
            var returnResult = okObjectResult.Value;
            Assert.IsType<List<Payment>>(returnResult);
        }

        [Fact]
        public void Should_Return2Payment_When_GetPaymentsByUser_PaymentsFound()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.GetPaymentsByUser("Thushy")).Returns(datas.SetListPaymentForTest);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.GetPaymentsByUser("Thushy");
            OkObjectResult okObjectResult = result as OkObjectResult;
            List<Payment> returnResult = okObjectResult.Value as List<Payment>;
            Assert.Equal(2, returnResult.Count);
        }

        [Fact]
        public void Should_ReturnBadRequest_When_GetPaymentsByUser_UserNotFound()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.GetPaymentsByUser(null)).Returns(datas.SetListPaymentForTest);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.GetPaymentsByUser(null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Should_ReturnEmptyPayment_When_GetPaymentsByUser_PaymentNotFound()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.GetPaymentsByUser("vThushy")).Returns(datas.SetEmptyListOfPaymentForTest);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.GetPaymentsByUser("vThushy");
            OkObjectResult okObjectResult = result as OkObjectResult;
            List<Payment> returnResult = okObjectResult.Value as List<Payment>;
            Assert.Empty(returnResult);
        }

        [Fact]
        public void Should_Return200Ok_When_GetPaymentsByUser_PaymentsNotFound()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.GetPaymentsByUser("Thushy")).Returns(datas.SetEmptyListOfPaymentForTest);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.GetPaymentsByUser("Thushy");
            Assert.IsType<OkObjectResult>(result);
        }
        #endregion

        #region Tests - MakePayment
        [Fact]
        public void Should_Return200Ok_When_MakePayment_PaymentSuccessfull()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.MakeAPayment(datas.SetPaymentForTest)).Returns(true);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.GetPaymentsByUser("Thushy");
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Should_ReturnPaymentMade_When_MakePayment_PaymentSuccessfull()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.MakeAPayment(datas.SetEmptyPaymentForTest)).Returns(false);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.MakePayment(datas.SetEmptyPaymentForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            var returnResult = okObjectResult.Value;
            Assert.Equal("Payment made.", returnResult);
        }
        [Fact]
        public void Should_Return200Ok_When_MakePayment_PaymentNotSuccessfull()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.MakeAPayment(datas.SetEmptyPaymentForTest)).Returns(false);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.MakePayment(datas.SetEmptyPaymentForTest);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Should_ReturnPaymentNotMade_When_MakePayment_PaymentNotSuccessfull()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.MakeAPayment(datas.SetEmptyPaymentForTest)).Returns(false);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.MakePayment(datas.SetEmptyPaymentForTest);
            OkObjectResult okObjectResult = result as OkObjectResult;
            var returnResult = okObjectResult.Value;
            Assert.Equal("Payment not made.", returnResult);
        }

        [Fact]
        public void Should_ReturnBadRequest_When_MakePayment_PaymentNull()
        {
            var _logger = Mock.Of<ILogger<PaymentController>>();
            _paymentRepository.Setup(r => r.MakeAPayment(null)).Returns(false);
            _controller = new PaymentController(_paymentRepository.Object, _orderRepository.Object, _logger,
                _productRepository.Object, _orderDetailsRepository.Object);
            IActionResult result = _controller.MakePayment(null);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        #endregion


    }
}

