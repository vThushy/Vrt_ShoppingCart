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
        private readonly ShoppingCartDbContext _shoppingCartDbContext;

        public OrderDetailsRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }
        public List<OrderDetail> GetOrderDetails(int OrderNo)
        {
            try
            {
                return _shoppingCartDbContext.OrderDetails.Where(o => o.OrderId == OrderNo).ToList();
            }
            catch 
            {
                throw;
            }
        }

    }
}
