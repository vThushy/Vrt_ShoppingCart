using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShoppingCart.Contracts
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrder(int id);
        List<OrderList> GetAllOrdersByCustomer(string userName);

        void AddOrder(Order order);
        void ModifyOrder(Order oldOrder, Order newOrder);
        void RemoveOrder(Order order);
    }
}
