using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Enum;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Repository
{
    public class CartRepository :ICartRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;

        //public CartRepository( ShoppingCartDbContext _shoppingCartDbContext)
        //{
        //    shoppingCartDbContext = _shoppingCartDbContext;
        //}

        //public int GetOrderId(int customerId)
        //{
        //    Status statusActive = Status.Active;
        //    var result = shoppingCartDbContext.Orders.FirstOrDefault(o => o.CustomerId == customerId && o.Status == statusActive);
        //    return result.Id;
        //}

        //public IList<OrderDetail> GetOrderDetails(int orderId)
        //{
        //    var result = shoppingCartDbContext.OrderDetails.Where(o => (o.OrderId == orderId));
        //    List<OrderDetail> orderDetails = result.ToList<OrderDetail>();
        //    return orderDetails;
        //}

    }
}
