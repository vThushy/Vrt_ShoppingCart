using ShoppingCart.Enum;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;

namespace ShoppingCart.Contracts
{
    public interface IOrderRepository
    {
        #region contracts
        List<Order> GetAllOrdersByCustomer(string userName);
        List<Order> GetAllOrders();
        List<Order> GetActiveOrder(string userName);
        OrderStatus OrderStatusChanged(int orderNo, Enum.OrderStatus status);
        Order GetOrder(int id);
        int AddOrder(Order order);
        Order ModifyOrder(int orderId, Order newOrder);
        Boolean RemoveOrder(int orderNo);
        #endregion
    }
}
