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
    }
}
