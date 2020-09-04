using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class OrderWithDetails
    {
        public Order order { get; set; }

        public List<OrderDetail> orderLines { get; set; }
    }
}
