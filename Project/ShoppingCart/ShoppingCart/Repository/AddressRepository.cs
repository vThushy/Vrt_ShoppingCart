using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;

        public AddressRepository(ShoppingCartDbContext _shoppingCartDbContext)
        {
            shoppingCartDbContext = _shoppingCartDbContext;
        }

        public void AddAddress(Address address)
        {
            try
            {
                shoppingCartDbContext.Addresses.Add(address);
                shoppingCartDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void RemoveAddress(Address address)
        {
            try
            {
                shoppingCartDbContext.Addresses.Remove(address);
                shoppingCartDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
