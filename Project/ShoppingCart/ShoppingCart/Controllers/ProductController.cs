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
        private readonly ILogger<ProductController> logger;
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository _productRepository, ILogger<ProductController> _logger)
        {
            logger = _logger;
            productRepository = _productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
            var response = productRepository.GetAllProducts();
            return Ok(response); 
            }
            catch (Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var response = productRepository.GetProduct(id);
                if (response == null)
                {
                    return NotFound("Product does not exist");
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpGet("/cat/{key}")]
        public IActionResult GetProductByCategory(string key)
        {
            try
            {
                var response = productRepository.GetProductsByCategory(key);
                if (response == null)
                {
                    return NotFound("Category does not exist!");
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
           
        }


        [HttpPost]
        public IActionResult AddProduct([FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product is null.");
                }

                productRepository.AddProduct(product);
                return CreatedAtRoute("Get", new { id = product.Id }, product);
            }
            catch (Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModifyProduct(int id, [FromBody] Product product)
        {
            try
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
            catch(Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            try
            {
                Product productToDelete = productRepository.GetProduct(id);
                if (productToDelete == null)
                {
                    return NotFound("The product not found!");
                }
                productRepository.RemoveProduct(productToDelete);
                logger.LogInformation($"Product {productToDelete.Id} deleted on {DateTime.UtcNow.ToLongTimeString()}");
                return NoContent();
            }
            catch(Exception e)
            {
                logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

    }
}
