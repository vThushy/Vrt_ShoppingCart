using Castle.Core.Configuration;
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
    public class Product_UnitTest
    {
        private Mock<IProductRepository> _productRepository;
        private ProductController _controller;

        public Product_UnitTest()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        #region Tests

        [Fact]
        public void Should_Return200Ok_When_GetAllProducts()
        {
            var _logger = Mock.Of<ILogger<ProductController>>();
            Datas datas = new Datas();

            _productRepository.Setup(r => r.GetAllProducts(1)).Returns(datas.SetProductListForTest);
            _controller = new ProductController(_productRepository.Object, _logger);

            IActionResult result = _controller.GetAllProducts(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Should_Return2Result_When_GetAllProducts_Return2Products()
        {
            var _logger = Mock.Of<ILogger<ProductController>>();
            Datas datas = new Datas();

            _productRepository.Setup(r => r.GetAllProducts(1)).Returns(datas.SetProductListForTest);
            _controller = new ProductController(_productRepository.Object, _logger);

            IActionResult result = _controller.GetAllProducts(1);
            OkObjectResult okObjectResult = result as OkObjectResult;
            ProductList resturnResult = okObjectResult.Value as ProductList;
            Assert.Equal(2, resturnResult.ListOfProducts.Count);
        }

        [Fact]
        public void Should_Return0Result_When_GetAllProducts_Return2Products()
        {
            var _logger = Mock.Of<ILogger<ProductController>>();
            Datas datas = new Datas();

            _productRepository.Setup(r => r.GetAllProducts(1)).Returns(datas.SetEmptyProductListForTest);
            _controller = new ProductController(_productRepository.Object, _logger);

            IActionResult result = _controller.GetAllProducts(1);
            OkObjectResult okObjectResult = result as OkObjectResult;
            ProductList resturnResult = okObjectResult.Value as ProductList;
            Assert.Equal(0, resturnResult.ListOfProducts.Count);
        }

        [Fact]
        public void Should_ReturnNoOfRecorde10_When_GetAllProducts_Return10Productts()
        {
            var _logger = Mock.Of<ILogger<ProductController>>();
            Datas datas = new Datas();

            _productRepository.Setup(r => r.GetAllProducts(1)).Returns(datas.SetProductListForTest);
            _controller = new ProductController(_productRepository.Object, _logger);

            IActionResult result = _controller.GetAllProducts(1);
            OkObjectResult okObjectResult = result as OkObjectResult;
            ProductList resturnResult = okObjectResult.Value as ProductList;
            Assert.Equal(10, resturnResult.NoOfProducts);
        }

        [Fact]
        public void Should_ReturnNoOfRecorde0_When_GetAllProducts_NoProductsFound()
        {
            var _logger = Mock.Of<ILogger<ProductController>>();
            Datas datas = new Datas();

            _productRepository.Setup(r => r.GetAllProducts(1)).Returns(datas.SetEmptyProductListForTest);
            _controller = new ProductController(_productRepository.Object, _logger);

            IActionResult result = _controller.GetAllProducts(1);
            OkObjectResult okObjectResult = result as OkObjectResult;
            ProductList resturnResult = okObjectResult.Value as ProductList;
            Assert.Equal(0, resturnResult.NoOfProducts);
        }

        #endregion

        [Fact]
        public void Should_Return200Ok_When_GetProduct_ProductFound()
        {
            var _logger = Mock.Of<ILogger<ProductController>>();
            Datas datas = new Datas();

            _productRepository.Setup(r => r.GetProductWithDetails(1)).Returns(datas.SetListOfProductForTest);
            _controller = new ProductController(_productRepository.Object, _logger);
            IActionResult result = _controller.GetProduct(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Should_ReturnProductType_When_GetProduct_ProductFound()
        {
            var _logger = Mock.Of<ILogger<ProductController>>();
            Datas datas = new Datas();

            _productRepository.Setup(r => r.GetProductWithDetails(1)).Returns(datas.SetListOfProductForTest);
            _controller = new ProductController(_productRepository.Object, _logger);
            IActionResult result = _controller.GetProduct(1);
            OkObjectResult okObjectResult = result as OkObjectResult;
            var returnResult = okObjectResult.Value;
            Assert.IsType<List<Product>>(returnResult);
        }

        [Fact]
        public void Should_Return2Product_When_GetProduct_ProductFoundWithDifferentSubProduct()
        {
            var _logger = Mock.Of<ILogger<ProductController>>();
            Datas datas = new Datas();

            _productRepository.Setup(r => r.GetProductWithDetails(1)).Returns(datas.SetListOfProductForTest);

            _controller = new ProductController(_productRepository.Object, _logger);
            IActionResult result = _controller.GetProduct(1);
            OkObjectResult okObjectResult = result as OkObjectResult;
            List<Product> resturnResult = okObjectResult.Value as List<Product>;
            Assert.Equal(2, resturnResult.Count);
        }


        [Fact]
        public void Should_Return200Ok_When_GetNewArrivalProducts_ProductFound()
        {
            var _logger = Mock.Of<ILogger<ProductController>>();
            Datas datas = new Datas();

            _productRepository.Setup(r => r.GetProductWithDetails(1)).Returns(datas.SetListOfProductForTest);
            _controller = new ProductController(_productRepository.Object, _logger);
            IActionResult result = _controller.GetProduct(1);
            Assert.IsType<OkObjectResult>(result);
        }
    }
}

