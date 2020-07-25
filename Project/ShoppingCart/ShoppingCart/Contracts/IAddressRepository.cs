using ShoppingCart.Models;

namespace ShoppingCart.Contracts
{
    public interface IAddressRepository
    {
        void AddAddress(Address address);
        void RemoveAddress(Address address);
    }
}
