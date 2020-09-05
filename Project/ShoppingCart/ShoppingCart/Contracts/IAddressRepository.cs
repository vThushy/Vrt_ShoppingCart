using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Contracts
{
    public interface IAddressRepository
    {
        #region contracts
        Address AddAddress(Address address);
        bool RemoveAddress(int addressId);
        List<Address> GetAddressesByUser(string userName);
        Address GetAddress(int addressId);
        #endregion
    }
}
