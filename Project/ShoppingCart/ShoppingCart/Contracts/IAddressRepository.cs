using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface IAddressRepository
    {
        public void AddAddress(Address address);
        public void RemoveAddress(Address address);
    }
}
