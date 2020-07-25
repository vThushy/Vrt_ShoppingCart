using Microsoft.Extensions.Logging;
using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;

        public OrderRepository(ShoppingCartDbContext _shoppingCartDbContext)
        {
            shoppingCartDbContext = _shoppingCartDbContext;
        }



        public IEnumerable<Order> GetAllOrdersByCustomer(string userName)
        {
            try
            {
                var customerId = shoppingCartDbContext.Customers.Where(c => c.UserName == userName).FirstOrDefault().Id;
                return shoppingCartDbContext.Orders.Where(o => o.CustomerId == customerId).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                return shoppingCartDbContext.Orders.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Order GetOrder(int id)
        {
            try
            {
            return shoppingCartDbContext.Orders.FirstOrDefault(p => (p.Id == id));
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void AddOrder(Order order)
        {
            try
            {
            shoppingCartDbContext.Orders.Add(order);
            shoppingCartDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
          
        }
        public void ModifyOrder(Order oldOrder, Order newOrder)
        {
            try
            {
            oldOrder.CustomerId = newOrder.CustomerId;
            oldOrder.AddressId = newOrder.AddressId;
            oldOrder.Discount = newOrder.Discount;
            oldOrder.Date = newOrder.Date;
            shoppingCartDbContext.SaveChanges();
            }
           catch(Exception e)
            {
                throw e;
            }

        }
        public void RemoveOrder(Order order)
        {
            try
            {
            shoppingCartDbContext.Orders.Remove(order);
            shoppingCartDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
