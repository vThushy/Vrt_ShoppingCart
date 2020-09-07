using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Contracts
{
    public interface IOrderRepository
    {
        #region contracts
        List<Order> GetAllOrdersByCustomer(string userName);
        List<Order> GetAllOrders();
        List<Order> GetActiveOrder(string userName);
        void OrderStatusChanged(int orderNo, Enum.OrderStatus status);
        Order GetOrder(int id);
        int AddOrder(Order order);
        void ModifyOrder(int orderId, Order newOrder);
        void RemoveOrder(int orderNo);
        #endregion
    }
}
