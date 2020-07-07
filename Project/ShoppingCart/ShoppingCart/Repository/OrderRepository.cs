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

        //public OrderRepository(ShoppingCartDbContext _shoppingCartDbContext)
        //{
        //    shoppingCartDbContext = _shoppingCartDbContext;
        //}

        //public IEnumerable<Order> GetAllOrders()
        //{
        //    return shoppingCartDbContext.Orders.ToList();
        //}

        //public Order GetOrder(int id)
        //{
        //    return shoppingCartDbContext.Orders.FirstOrDefault(p => (p.Id == id));
        //}

        //public void AddOrder(Order order)
        //{
        //    shoppingCartDbContext.Orders.Add(order);
        //    shoppingCartDbContext.SaveChanges();
        //}
        //public void ModifyOrder(Order oldOrder, Order newOrder)
        //{
        //    oldOrder.CustomerId = newOrder.CustomerId;
        //    oldOrder.AddressId = newOrder.AddressId;
        //    oldOrder.Discount = newOrder.Discount;
        //    oldOrder.Date = newOrder.Date;
        //    shoppingCartDbContext.SaveChanges();

        //}
        //public void RemoveOrder(Order order)
        //{
        //    shoppingCartDbContext.Orders.Remove(order);
        //    shoppingCartDbContext.SaveChanges();
        //}
    }
}
