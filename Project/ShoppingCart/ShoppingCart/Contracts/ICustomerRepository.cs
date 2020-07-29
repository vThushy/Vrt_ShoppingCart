using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface ICustomerRepository
    {
        #region contracts
        Customer GetCustomer(string userName);
        void AddCustomer(Customer customer);
        void ModifyCustomer(string userName, Customer newCustomer);
        void RemoveCustomer(string userName);
        #endregion
    }
}
