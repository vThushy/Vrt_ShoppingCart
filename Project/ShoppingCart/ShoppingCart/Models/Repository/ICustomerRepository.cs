using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        void AddCustomer(Customer customer);

        void ModifyCustomer(Customer oldCustomer, Customer newCustomer);
        void RemoveCustomer(Customer customer);

    }
}
