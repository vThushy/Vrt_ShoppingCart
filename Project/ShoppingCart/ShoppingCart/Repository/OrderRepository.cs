using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
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
                    List<Order> orders = _shoppingCartDbContext.Orders.Where(o => o.UserName == userName).ToList();
                    return orders;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public Order GetActiveOrder(string userName)
        {
            try
            {
                if (userName != null)
                {
                    Order activeOrder = _shoppingCartDbContext.Orders.Where(o => o.UserName == userName &&
                                    o.OrderStatus == Enum.OrderStatus.Active).FirstOrDefault(); ;
                    return activeOrder;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public void AcceptOrder(int orderNo)
        {
            try
            {
                if (orderNo > 0)
                {
                    var orderNeedstoReleased = _shoppingCartDbContext.Orders.Where(o => o.Id == orderNo).FirstOrDefault();
                    orderNeedstoReleased.OrderStatus = Enum.OrderStatus.Accepted;
                    _shoppingCartDbContext.SaveChanges();
                }
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

        public void ModifyOrder(int orderId, Order newOrder)
        {
            //try
            //{
            //    if (orderId > 0 && newOrder != null)
            //    {
            //        Order order = _shoppingCartDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();
            //        order.AddressId = newOrder.AddressId;
            //        order.Discount = newOrder.Discount;
            //        order.Date = newOrder.Date;
            //        order.OrderStatus = newOrder.OrderStatus;
            //        order.OrderLines = newOrder.OrderLines; 
            //        _shoppingCartDbContext.SaveChanges();
            //    }
            //}
            //catch
            //{
            //    throw;
            //}
        }

        public void RemoveOrder(int orderNo)
        {
            try
            {
                if (orderNo > 0)
                {
                    Order order = _shoppingCartDbContext.Orders.Where(o => o.Id == orderNo).FirstOrDefault();
                    //   var orderDetail = _shoppingCartDbContext.OrderDetails.Where(d => d.OrderId == orderNo).ToList();
                    _shoppingCartDbContext.Orders.Remove(order);
                    //foreach (OrderDetail o in orderDetail)
                    //{
                    //    _shoppingCartDbContext.OrderDetails.Remove(o);
                    //}
                    _shoppingCartDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
