﻿using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Enum;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Repository
{
    public class OrderRepository : IOrderRepository
    {
        #region class variables
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        #endregion

        #region constructor
        public OrderRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }
        #endregion

        #region methods
        public List<Order> GetAllOrdersByCustomer(string userName)
        {
            try
            {
                if (userName != null)
                {
                    List<Order> orders = _shoppingCartDbContext.Orders.Where(o => o.UserName == userName && o.OrderStatus != Enum.OrderStatus.Active).ToList();
                    return orders;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public List<Order> GetActiveOrder(string userName)
        {
            try
            {
                if (userName != null)
                {
                    List<Order> activeOrder = _shoppingCartDbContext.Orders.Where(o => o.UserName == userName &&
                                    o.OrderStatus == Enum.OrderStatus.Active).ToList();
                    return activeOrder;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public OrderStatus OrderStatusChanged(int orderNo, OrderStatus status)
        {
            try
            {
                if (orderNo > 0)
                {
                    var orderNeedstoReleased = _shoppingCartDbContext.Orders.Where(o => o.Id == orderNo).FirstOrDefault();
                    orderNeedstoReleased.OrderStatus = status;
                    _shoppingCartDbContext.SaveChanges();
                    return status;
                }
                return Enum.OrderStatus.NULL;
            }
            catch
            {
                throw;
            }
        }

        public List<Order> GetAllOrders()
        {
            try
            {
                return _shoppingCartDbContext.Orders.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Order GetOrder(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _shoppingCartDbContext.Orders.FirstOrDefault(p => (p.Id == id));
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public int AddOrder(Order order)
        {
            int id;
            try
            {
                if (order != null)
                {
                    _shoppingCartDbContext.Orders.Add(order);
                    _shoppingCartDbContext.SaveChanges();
                    id = order.Id;
                    id = order.Id;
                    return id;
                }
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public Order ModifyOrder(int orderId, Order newOrder)
        {
            try
            {
                if (orderId > 0 && newOrder != null)
                {
                    Order order = _shoppingCartDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();
                    order.AddressId = newOrder.AddressId;
                    order.Discount = newOrder.Discount;
                    order.Date = newOrder.Date;
                    order.OrderStatus = newOrder.OrderStatus;
                    _shoppingCartDbContext.SaveChanges();
                    return order;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public Boolean RemoveOrder(int orderNo)
        {
            try
            {
                if (orderNo > 0)
                {
                    Order order = _shoppingCartDbContext.Orders.Where(o => o.Id == orderNo).FirstOrDefault();
                    _shoppingCartDbContext.Orders.Remove(order);
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
