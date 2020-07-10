using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using ShoppingCart.Repository;
using System;
using System.Threading.Tasks;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController: ControllerBase
    {
        private readonly ILogger<CustomerController> logger;
        private readonly ICustomerRepository customerRepository;
        private readonly IUserRepository userRepository;
        private readonly IAddressRepository addressRepository;

        public CustomerController(
            ICustomerRepository _customerRepository,
            IUserRepository _userRepository,
            IAddressRepository _addressRepository,
            ILogger<CustomerController> _logger)
        {
            logger = _logger;
            customerRepository = _customerRepository;
            userRepository = _userRepository;
            addressRepository = _addressRepository;
        }


        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var response = customerRepository.GetCustomer(id);
            if (response == null)
            {
                return NotFound("Customer does not exist");
            }
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerRegObj customerRegObj)
        {
            Customer customer = customerRegObj.Customer;
            User user = customerRegObj.User;
            Address address = customerRegObj.Address;

            if (customer == null && user == null)
            {
                return BadRequest("Request is null.");
            }

            try
            {
                customerRepository.AddCustomer(customer);
                userRepository.AddUser(user);
                addressRepository.AddAddress(address);
                return Ok("Customer created.");
            }
            catch(Exception e)
            {
                logger.LogError("Error in CustomerController: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModifyCustomer(int id, [FromBody] Customer customer)
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
        public IActionResult RemoveCustomer(int id)
        {
            Customer customerToDelete = customerRepository.GetCustomer(id);
            if (customerToDelete == null)
            {
                return NotFound("The customer not found!");
            }
            customerRepository.RemoveCustomer(customerToDelete);
            logger.LogInformation($"Customer {customerToDelete.Id} deleted on {DateTime.UtcNow.ToLongTimeString()}");
            return NoContent();
        }
    }

    public class CustomerRegObj
    {
        public Customer Customer { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
    }
}
