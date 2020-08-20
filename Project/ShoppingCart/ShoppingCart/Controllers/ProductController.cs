using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;
using ShoppingCart.Contracts;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet()]
        [Route("/product/page/{pageIndex}")]
        public IActionResult GetAllProducts(int pageIndex)
        {
            try
            {
                var response = _productRepository.GetAllProducts(pageIndex);
                return Ok(response); 
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var response = _productRepository.GetProductWithDetails(id);
                if (response == null)
                {
                    return NotFound("Product does not exist");
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpGet]
        [Route("/new-arrival/{category}")]
        public IActionResult GetNewArrivalProducts(string category)
        {
            try
            {
                var response = _productRepository.GetNewArrivalProducts(category);
                if (response == null)
                {
                    return NotFound("New arrival products does not exist!");
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpGet]
        [Route("/best-seller/{category}")]
        public IActionResult GetBestSellingProducts(string category)
        {
            try
            {
                var response = _productRepository.GetBestSellerProducts(category);
                if (response == null)
                {
                    return NotFound("best selling products does not exist!");
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpGet("/category/{key}/{pageIndex}")]
        public IActionResult GetProductByCategory(string key, int pageIndex)
        {
            try
            {
                var response = _productRepository.GetProductsByCategory(key, pageIndex);
                if (response == null)
                {
                    return NotFound("Category does not exist!");
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }    
        }

        [HttpGet("/filter/{key}/{pageIndex}")]
        public IActionResult GetProductBySearch(string key, int pageIndex)
        {
            try
            {
                var response = _productRepository.GetProductsBySearch(key, pageIndex);
                if (response == null)
                {
                    return NotFound("Product does not exist!");
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("Error in Product controller : " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpPost("/cart")]
        public IActionResult GetCartProducts([FromBody] string[] productIds)
        {
            try
            {
                if (productIds == null)
                {
                    return BadRequest("Product is null.");
                }

                List<Product> products = _productRepository.GetProductListById(productIds);
                return Ok(new { cartItems = products });
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
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

                _productRepository.AddProduct(product);
                return CreatedAtRoute("Get", new { id = product.Id }, product);
            }
            catch (Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
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

                Product productToUpdate = _productRepository.GetProduct(id);
                if (productToUpdate == null)
                {
                    return NotFound("The product not found!");
                }

                //_productRepository.ModifyProduct(productToUpdate, product);
                return NoContent();
            }
            catch(Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            try
            {
                Product productToDelete = _productRepository.GetProduct(id);
                if (productToDelete == null)
                {
                    return NotFound("The product not found!");
                }
               // _productRepository.RemoveProduct(productToDelete);
                _logger.LogInformation($"Product {productToDelete.Id} deleted on {DateTime.UtcNow.ToLongTimeString()}");
                return NoContent();
            }
            catch(Exception e)
            {
                _logger.LogError("\n Error: {0}", e);
                return Problem(e.ToString());
            }
        }

    }
}
