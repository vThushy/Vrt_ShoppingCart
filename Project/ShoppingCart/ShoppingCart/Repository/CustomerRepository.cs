using ShoppingCart.Contexts;
using System.Linq;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;

namespace ShoppingCart.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        #region class variables
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        #endregion

        #region constructor
        public CustomerRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }
        #endregion

        #region methods

        public Customer GetCustomer(string userName)
        {
            try
            {
                return _shoppingCartDbContext.Customers.FirstOrDefault(c => c.UserName == userName);
            }
            catch
            {
                throw;
            }
        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                if (customer != null)
                {
                    _shoppingCartDbContext.Customers.Add(customer);
                    _shoppingCartDbContext.SaveChanges();
                    return customer;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public Customer ModifyCustomer(string userName, Customer updateCustomer)
        {
            try
            {
                if (userName != null && updateCustomer != null)
                {
                    Customer customer = _shoppingCartDbContext.Customers.Where(c => c.UserName == userName).FirstOrDefault();
                    customer.FirstName = updateCustomer.FirstName;
                    customer.LastName = updateCustomer.LastName;
                    customer.Gender = updateCustomer.Gender;
                    customer.DateOfBirth = updateCustomer.DateOfBirth;
                    customer.Email = updateCustomer.Email;
                    customer.Phone = updateCustomer.Phone;

                    _shoppingCartDbContext.SaveChanges();
                    return updateCustomer;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public Boolean RemoveCustomer(string userName)
        {
            try
            {
                if (userName != null)
                {
                    Customer customer = _shoppingCartDbContext.Customers.Where(c => c.UserName == userName).FirstOrDefault();
                    _shoppingCartDbContext.Customers.Remove(customer);
                    _shoppingCartDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}

