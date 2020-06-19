using ShoppingCart.Models;
using ShoppingCart.Models.Repository;
using ShoppingCart.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext customerDbContext;

        public CustomerRepository(CustomerDbContext _customerDbContext)
        {
            customerDbContext = _customerDbContext;
        }
   
        public Customer GetCustomer(int id)
        {
            return customerDbContext.Customers.FirstOrDefault(c => c.Id == id);
        }
        public void AddCustomer(Customer customer)
        {
            customerDbContext.Customers.Add(customer);
            customerDbContext.SaveChanges();
        }
        public void ModifyCustomer(Customer oldCustomer, Customer newCustomer)
        {
            oldCustomer.FirstName = newCustomer.FirstName;
            oldCustomer.LastName = newCustomer.LastName;
            oldCustomer.Address = newCustomer.Address;
            oldCustomer.Gender = newCustomer.Gender;
            oldCustomer.DateOfBirth = newCustomer.DateOfBirth;
            oldCustomer.Email = newCustomer.Email;
            oldCustomer.Phone = newCustomer.Phone;

            customerDbContext.SaveChanges();
        }

        public void RemoveCustomer(Customer customer)
        {
            customerDbContext.Customers.Remove(customer);
            customerDbContext.SaveChanges();
        }
    }
}
