using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        #region class variables
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        #endregion

        #region constructor
        public CustomerController(
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            IAddressRepository addressRepository,
            ILogger<CustomerController> logger)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }
        #endregion

        #region methods

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                var response = _customerRepository.GetCustomer(id);
                if (response == null)
                {
                    return NotFound("Customer does not exist");
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError("Error in CustomerController: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerRegObj customerRegObj)
        {
            try
            {
                if (customerRegObj != null)
                {
                    Customer customer = customerRegObj.Customer;
                    User user = customerRegObj.User;
                    Address address = customerRegObj.Address;
                    _customerRepository.AddCustomer(customer);
                    _userRepository.AddUser(user);
                    _addressRepository.AddAddress(address);
                    return Ok("Customer created.");
                }
                else
                {
                    return BadRequest("Request is null.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error in CustomerController: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpPut("{id}")]
        public IActionResult ModifyCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("Customer is null.");
                }

                Customer customerToUpdate = _customerRepository.GetCustomer(id);
                if (customerToUpdate == null)
                {
                    return NotFound("The customer not found!");
                }

                _customerRepository.ModifyCustomer(customerToUpdate, customer);
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError("Error in CustomerController: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCustomer(int id)
        {
            Customer customerToDelete = _customerRepository.GetCustomer(id);
            try
            {
                if (customerToDelete == null)
                {
                    return NotFound("The customer not found!");
                }
                _customerRepository.RemoveCustomer(customerToDelete);
                _logger.LogInformation($"Customer {customerToDelete.Id} deleted on {DateTime.UtcNow.ToLongTimeString()}");
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError("Error in CustomerController: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        #endregion
    }

    public class CustomerRegObj
    {
        public Customer Customer { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
    }
}
