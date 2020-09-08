using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using ShoppingCart.Utility;
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
        private readonly IConfiguration _configuration;
        #endregion

        #region constructor
        public CustomerController(
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            IAddressRepository addressRepository,
            ILogger<CustomerController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _configuration = configuration;
        }
        #endregion

        #region methods

        //[HttpGet("{id}")]
        //public IActionResult GetCustomer(int id)
        //{
        //    try
        //    {
        //        //var response = _customerRepository.GetCustomer(id);
        //        //if (response == null)
        //        //{
        //        //    return NotFound("Customer does not exist");
        //        //}
        //        //return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError("Error in CustomerController: " + e.ToString());
        //        return Problem(e.ToString());
        //    }
        //}

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

                    Token token = new Token(_configuration);
                    var tokenString = token.GenerateJSONWebToken();
                    _logger.LogInformation($"User {user.UserName} login on {DateTime.UtcNow.ToLongTimeString()}");
                    ResponseUser resSuccess = new ResponseUser(user.UserName, tokenString);
                    return Ok(resSuccess);
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
        public IActionResult ModifyCustomer(string userName, [FromBody] Customer customer)
        {
            try
            {
                Customer customerToUpdate = _customerRepository.GetCustomer(userName);
                if (customerToUpdate != null)
                {
                    _customerRepository.ModifyCustomer(userName, customer);
                }
                return NotFound("The customer not found!");
            }
            catch (Exception e)
            {
                _logger.LogError("Error in CustomerController: " + e.ToString());
                return Problem(e.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCustomer(string userName)
        {
            try
            {
                if (userName == null)
                {
                    return NotFound("The customer not found!");
                }
                _customerRepository.RemoveCustomer(userName);
                _logger.LogInformation($"Customer {userName} deleted on {DateTime.UtcNow.ToLongTimeString()}");
                return Ok();
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
