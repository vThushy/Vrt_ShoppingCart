using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;
using ShoppingCart.Contracts;
using System;

namespace ShoppingCart.Controllers
{
    [Authorize]
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository productRepository;

        //public ProductController(IProductRepository _productRepository, ILogger<ProductController> logger)
        //{
        //    _logger = logger;
        //    productRepository = _productRepository;
        //}

        //[HttpGet]
        //public IActionResult GetAllProducts()
        //{
        //    var response = productRepository.GetAllProducts();
        //    return Ok(response);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetProduct(int id)
        //{
        //    var response = productRepository.GetProduct(id);
        //    if (response == null)
        //    {
        //        return NotFound("Product does not exist");
        //    }
        //    return Ok(response);
        //}

        //[HttpPost]
        //public IActionResult AddProduct([FromBody] Product product)
        //{
        //    if (product == null)
        //    {
        //        return BadRequest("Product is null.");
        //    }

        //    productRepository.AddProduct(product);
        //    return CreatedAtRoute("Get", new { id = product.Id }, product);
        //}

        //[HttpPut("{id}")]
        //public IActionResult ModifyProduct(int id, [FromBody] Product product)
        //{
        //    if (product == null)
        //    {
        //        return BadRequest("Product is null.");
        //    }

        //    Product productToUpdate = productRepository.GetProduct(id);
        //    if (productToUpdate == null)
        //    {
        //        return NotFound("The product not found!");
        //    }

        //    productRepository.ModifyProduct(productToUpdate, product);
        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult RemoveProduct(int id)
        //{
        //    Product productToDelete = productRepository.GetProduct(id);
        //    if (productToDelete == null)
        //    {
        //        return NotFound("The product not found!");
        //    }
        //    productRepository.RemoveProduct(productToDelete);
        //    _logger.LogInformation($"Product {productToDelete.Id} deleted on {DateTime.UtcNow.ToLongTimeString()}");
        //    return NoContent();
        //}

    }
}
