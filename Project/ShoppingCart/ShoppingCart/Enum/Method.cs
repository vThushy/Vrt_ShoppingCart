using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Enum
{
    /// <summary>
    /// Payment Method
    /// </summary>
    public enum Method
    {
        /// <summary>
        /// Pay By Cash
        /// </summary>
        Cash = 0,

        /// <summary>
        /// Pay By Shop Credit
        /// </summary>
        ShopCredit = 1,

        /// <summary>
        /// Pay By Cart
        /// </summary>
        Cart = 2

    }
}
