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
        Customer AddCustomer(Customer customer);
        Customer ModifyCustomer(string userName, Customer newCustomer);
        Boolean RemoveCustomer(string userName);
        #endregion
    }
}
