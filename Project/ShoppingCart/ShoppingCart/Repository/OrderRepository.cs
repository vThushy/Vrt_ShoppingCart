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
        private readonly OrderDetailsRepository _orderDetailsRepository;
        #endregion

        #region constructor
        public OrderRepository(ShoppingCartDbContext shoppingCartDbContext, OrderDetailsRepository orderDetailsRepository)
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

        public void ReleaseOrder(int orderNo)
        {
            try
            {
                if (orderNo > 0)
                {
                    var orderNeedstoReleased = _shoppingCartDbContext.Orders.Where(o => o.Id == orderNo).FirstOrDefault();
                    orderNeedstoReleased.OrderStatus = Enum.OrderStatus.Released;
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

        public void AddOrder(Order order)
        {
            try
            {
                if (order != null)
                {
                    _shoppingCartDbContext.Orders.Add(order);
                    _shoppingCartDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public void RemoveOrder(int orderNo)
        {
            try
            {
                if (orderNo > 0)
                {
                    Order order = _shoppingCartDbContext.Orders.Where(o => o.Id == orderNo).FirstOrDefault();
                    var orderDetail = _shoppingCartDbContext.OrderDetails.Where(d => d.OrderId == orderNo).ToList();
                    _shoppingCartDbContext.Orders.Remove(order);
                    foreach (OrderDetail o in orderDetail)
                    {
                        _shoppingCartDbContext.OrderDetails.Remove(o);
                    }
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
