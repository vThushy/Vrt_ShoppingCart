using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);
        void ModifyCustomer(Customer oldCustomer, Customer newCustomer);
        void RemoveCustomer(Customer customer);
        int GetCustomerId(string userName);

    }
}
