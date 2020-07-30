using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Contracts
{
    public interface IAddressRepository
    {
        #region contracts
        void AddAddress(Address address);
        void RemoveAddress(int addressId);
        List<Address> GetAddressesByUser(string userName);
        Address GetAddress(int addressId);
        #endregion
    }
}
