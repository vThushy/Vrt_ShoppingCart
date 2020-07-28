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
        Released = 1,

        /// <summary>
        /// 
        /// </summary>
        Completed = 2
    }
}

