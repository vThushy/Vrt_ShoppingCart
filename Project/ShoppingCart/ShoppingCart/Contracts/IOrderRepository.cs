using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Contracts
{
    public interface IOrderRepository
    {
        #region contracts
        List<Order> GetAllOrdersByCustomer(string userName);
        List<Order> GetAllOrders();
        Order GetOrder(int id);
        void AddOrder(Order order);
        void ModifyOrder(int orderId, Order newOrder);
        void RemoveOrder(int orderNo);
        #endregion
    }
}
