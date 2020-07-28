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
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        private readonly OrderDetailsRepository _orderDetailsRepository;

        public OrderRepository(ShoppingCartDbContext shoppingCartDbContext, OrderDetailsRepository orderDetailsRepository)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public List<OrderList> GetAllOrdersByCustomer(string userName)
        {
            try
            {
                List<OrderList> orderLists = new List<OrderList>();
                var customerId = _shoppingCartDbContext.Customers.Where(c => c.UserName == userName).FirstOrDefault().Id;
                int[] orders = _shoppingCartDbContext.Orders.Where(o => o.CustomerId == customerId).Select(o => o.Id).ToArray();

                foreach (int id in orders)
                {
                    var lines = _orderDetailsRepository.GetOrderDetails(id);

                    OrderList oList = new OrderList
                    {
                        orderNo = id,
                        orderLines = lines
                    };
                    orderLists.Add(oList);
                }
                return orderLists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public OrderList GetActiveOrdersByCustomer(string userName)
        {
            try
            {
                var customerId = _shoppingCartDbContext.Customers.Where(c => c.UserName == userName).FirstOrDefault().Id;
                var orderId = _shoppingCartDbContext.Orders.Where(o => o.CustomerId == customerId && o.OrderStatus == Enum.OrderStatus.Active).FirstOrDefault().Id;
                var lines = _orderDetailsRepository.GetOrderDetails(orderId);

                return new OrderList
                {
                    orderNo = orderId,
                    orderLines = lines
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void PlaceOrder(int orderNo)
        {
            try
            {
                var orderNeedstoReleased = _shoppingCartDbContext.Orders.Where(o => o.Id == orderNo).FirstOrDefault();
                orderNeedstoReleased.OrderStatus = Enum.OrderStatus.Released;
                _shoppingCartDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }


        public IEnumerable<Order> GetAllOrders()
        {
            try
            {
                return _shoppingCartDbContext.Orders.ToList();
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
                return _shoppingCartDbContext.Orders.FirstOrDefault(p => (p.Id == id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void AddOrder(Order order)
        {
            try
            {
                _shoppingCartDbContext.Orders.Add(order);
                _shoppingCartDbContext.SaveChanges();
            }
            catch (Exception e)
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
                _shoppingCartDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void RemoveOrder(Order order)
        {
            try
            {
                _shoppingCartDbContext.Orders.Remove(order);
                _shoppingCartDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
