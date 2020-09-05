using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Repository
{
    public class AddressRepository : IAddressRepository
    {
        #region class variables
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        #endregion

        #region constructor
        public AddressRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }
        #endregion

        #region methods

        public List<Address> GetAddressesByUser(string userName)
        {
            try
            {
                if (userName != null)
                {
                    return _shoppingCartDbContext.Addresses.Where(a => a.UserName == userName).ToList();
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public Address GetAddress(int addressId)
        {
            try
            {
                if (addressId > 0)
                {
                    return _shoppingCartDbContext.Addresses.FirstOrDefault(a => a.Id == addressId);
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public Address AddAddress(Address address)
        {
            try
            {
                if (address != null)
                {
                    _shoppingCartDbContext.Addresses.Add(address);
                    _shoppingCartDbContext.SaveChanges();
                    return address;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public bool RemoveAddress(int addressId)
        {
            try
            {
                if (addressId > 0)
                {
                    Address address = _shoppingCartDbContext.Addresses.Where(a => a.Id == addressId).FirstOrDefault();
                    _shoppingCartDbContext.Addresses.Remove(address);
                    _shoppingCartDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
