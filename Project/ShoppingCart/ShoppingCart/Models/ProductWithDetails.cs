using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ProductWithDetails
    {
        #region Properties
        public Product Product { get; set; }
        public List<ProductDetails> ProductDetails { get; set; }
        #endregion
    }
}

