using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        #region class variables
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        #endregion

        #region constructor
        public OrderDetailsRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }
        #endregion

        public void AddOrderLine(OrderDetail order)
        {
            try
            {
                if (order != null)
                {
                    _shoppingCartDbContext.OrderDetails.Add(order);
                    _shoppingCartDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<OrderDetail> GetOrderLines(int orderId)
        {
            try
            {
                if (orderId > 0)
                {
                    return _shoppingCartDbContext.OrderDetails.Where(o => (o.OrderId == orderId)).ToList();
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
    }
}
