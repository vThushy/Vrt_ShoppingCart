using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class OrderList
    {
        public int orderNo
        {
            get;
            set;
        }
        public List<OrderDetail> orderLines
        {
            get;
            set;
        }
    }
}
