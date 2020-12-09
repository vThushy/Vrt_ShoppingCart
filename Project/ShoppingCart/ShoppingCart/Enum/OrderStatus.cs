using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Enum
{
    /// <summary>
    /// Sattus of Order
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Order 
        /// </summary>
        Active = 0,
        
        /// <summary>
        /// order after payment
        /// </summary>
        Paid = 1,


        /// <summary>
        /// 
        /// </summary>
        Accepted = 2,

        /// <summary>
        /// 
        /// </summary>
        Shipped = 3,

        /// <summary>
        /// 
        /// </summary>
        Delivered = 4,

        /// <summary>
        /// 
        /// </summary>
        Completed = 5,

        /// <summary>
        /// 
        /// </summary>
        NULL = 10,




    }
}

