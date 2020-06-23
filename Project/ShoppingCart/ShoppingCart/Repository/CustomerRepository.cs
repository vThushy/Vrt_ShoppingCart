using ShoppingCart.Models;
using ShoppingCart.Models.Repository;
using ShoppingCart.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;

        public CustomerRepository(ShoppingCartDbContext _shoppingCartDbContext)
        {
            shoppingCartDbContext = _shoppingCartDbContext;
        }
   
        public Customer GetCustomer(int id)
        {
            return shoppingCartDbContext.Customers.FirstOrDefault(c => c.Id == id);
        }
        public void AddCustomer(Customer customer)
        {
            shoppingCartDbContext.Customers.Add(customer);
            shoppingCartDbContext.SaveChanges();
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

            shoppingCartDbContext.SaveChanges();
        }

        public void RemoveCustomer(Customer customer)
        {
            shoppingCartDbContext.Customers.Remove(customer);
            shoppingCartDbContext.SaveChanges();
        }
    }
}
