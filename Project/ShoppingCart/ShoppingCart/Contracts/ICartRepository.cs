using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Contracts
{
    public interface ICartRepository
    {
        public int GetOrderId(int customerId);
        public IList<OrderDetail> GetOrderDetails(int orderId);
    }
}
