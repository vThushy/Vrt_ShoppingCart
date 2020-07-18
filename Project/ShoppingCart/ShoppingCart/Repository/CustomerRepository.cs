using ShoppingCart.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Contracts;
using ShoppingCart.Models;

namespace ShoppingCart.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;

        public CustomerRepository(ShoppingCartDbContext _shoppingCartDbContext)
        {
            shoppingCartDbContext = _shoppingCartDbContext;
        }

        public int GetCustomerId(string userName)
        {
            var result = shoppingCartDbContext.Customers.Where(c => c.UserName == userName).Select(c => new Customer { Id = c.Id }).SingleOrDefault();
            return result.Id;
        }
        public Customer GetCustomer(int id)
        {
            try
            {
                return shoppingCartDbContext.Customers.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void AddCustomer(Customer customer)
        {
            try
            {
                shoppingCartDbContext.Customers.Add(customer);
                shoppingCartDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void ModifyCustomer(Customer oldCustomer, Customer newCustomer)
        {
            try
            {
            oldCustomer.FirstName = newCustomer.FirstName;
            oldCustomer.LastName = newCustomer.LastName;
            oldCustomer.Gender = newCustomer.Gender;
            oldCustomer.DateOfBirth = newCustomer.DateOfBirth;
            oldCustomer.Email = newCustomer.Email;
            oldCustomer.Phone = newCustomer.Phone;

            shoppingCartDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void RemoveCustomer(Customer customer)
        {
            try
            {
                shoppingCartDbContext.Customers.Remove(customer);
                shoppingCartDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
