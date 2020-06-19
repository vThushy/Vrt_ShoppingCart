using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;
using ShoppingCart.Models.Repository;
using ShoppingCart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository _productRepository, ILogger<ProductController> logger)
        {
            _logger = logger;
            productRepository = _productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = productRepository.GetAllProducts();
           
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = productRepository.GetProduct(id);
            if (response == null)
            {
                return NotFound("Product does not exist");
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }
            
            productRepository.AddProduct(product);
            return CreatedAtRoute("Get", new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            Product productToUpdate = productRepository.GetProduct(id);
            if (productToUpdate == null)
            {
                return NotFound("The product not found!");
            }

            productRepository.ModifyProduct(productToUpdate, product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product productToDelete = productRepository.GetProduct(id);
            if (productToDelete == null)
            {
                return NotFound("The product not found!");
            }
            productRepository.RemoveProduct(productToDelete);
            _logger.LogInformation($"Product {productToDelete.Id} deleted on {DateTime.UtcNow.ToLongTimeString()}");
            return NoContent();
        }

    }
}
