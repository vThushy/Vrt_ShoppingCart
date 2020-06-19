using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Models;
using ShoppingCart.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController: ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository _customerRepository, ILogger<CustomerController> logger)
        {
            _logger = logger;
            customerRepository = _customerRepository;
        }

      
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = customerRepository.GetCustomer(id);
            if (response == null)
            {
                return NotFound("Customer does not exist");
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Product is null.");
            }

            customerRepository.AddCustomer(customer);
            return CreatedAtRoute("Get", new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Product is null.");
            }

            Customer customerToUpdate = customerRepository.GetCustomer(id);
            if (customerToUpdate == null)
            {
                return NotFound("The customer not found!");
            }

            customerRepository.ModifyCustomer(customerToUpdate, customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer customerToDelete = customerRepository.GetCustomer(id);
            if (customerToDelete == null)
            {
                return NotFound("The customer not found!");
            }
            customerRepository.RemoveCustomer(customerToDelete);
            _logger.LogInformation($"Customer {customerToDelete.Id} deleted on {DateTime.UtcNow.ToLongTimeString()}");
            return NoContent();
        }
    }
}
