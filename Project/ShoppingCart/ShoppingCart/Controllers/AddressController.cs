using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Controllers
{
    [ApiController]
    [Route("address")]
    public class AddressController : ControllerBase
    {
        #region class variables
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressRepository _addressRepository;
        private string error;
        #endregion

        #region constructor
        public AddressController(
            ILogger<AddressController> logger,
            IAddressRepository addressRepository
            )
        {
            _logger = logger;
            _addressRepository = addressRepository;
        }
        #endregion

        #region methods

        [HttpGet("{userName}")]
        public IActionResult GetAllAddressByCustomer(string userName)
        {
            try
            {
                if (userName != null)
                {
                    List<Address> addresses = _addressRepository.GetAddressesByUser(userName);
                    if (addresses == null)
                    {
                        return NotFound("Customer does not exist");
                    }
                    return Ok(addresses);
                }
                return BadRequest("Request object is null");
            }
            catch (Exception e)
            {
                error = "Error in CustomerController: " + e.ToString();
                _logger.LogError(error);
                return Problem(error);
            }
        }

        [HttpPost]
        public IActionResult AddAddress(Address address)
        {
            try
            {
                if (address != null)
                {
                    _addressRepository.AddAddress(address);
                    return Ok(address);
                }
                return BadRequest("Request object is null");
            }
            catch (Exception e)
            {
                error = "Error in CustomerController: " + e.ToString();
                _logger.LogError(error);
                return Problem(error);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveAddress(int id)
        {
            try
            {
                if (id > 0)
                {
                    if (_addressRepository.RemoveAddress(id))
                    {
                        return Ok();
                    }
                }
                return BadRequest("Request object is null");
            }
            catch (Exception e)
            {
                error = "Error in CustomerController: " + e.ToString();
                _logger.LogError(error);
                return Problem(error);
            }
        }

        [HttpGet("/by-id/{id}")]
        public IActionResult GetAddressById(int id)
        {
            try
            {
                if (id != null)
                {
                    Address addresses = _addressRepository.GetAddress(id);
                    if (addresses == null)
                    {
                        return NotFound("Address does not exist");
                    }
                    return Ok(addresses);
                }
                return BadRequest("Request object is null");
            }
            catch (Exception e)
            {
                error = "Error in AddressController: " + e.ToString();
                _logger.LogError(error);
                return Problem(error);
            }
        }

        #endregion
    }
}
