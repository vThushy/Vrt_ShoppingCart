using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ProductList
    {
        public int NoOfProducts
        {
            get;set;
        }
        public List<Product> ListOfProducts
        {
            get;
            set;
        }
    }
}
