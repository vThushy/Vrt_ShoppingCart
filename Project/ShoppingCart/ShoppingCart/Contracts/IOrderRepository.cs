using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Contracts
{
    public interface IOrderRepository
    {
        #region contracts
        List<Order> GetAllOrders();
        Order GetOrder(int id);
        List<Order> GetAllOrdersByCustomer(string userName);
        void AddOrder(Order order);
        void RemoveOrder(int orderNo);
        #endregion
    }
}
