using ShoppingCart.Models;

namespace ShoppingCart.Contracts
{
    public interface IAddressRepository
    {
        #region contracts
        void AddAddress(Address address);
        void RemoveAddress(int addressId);
        #endregion
    }
}
