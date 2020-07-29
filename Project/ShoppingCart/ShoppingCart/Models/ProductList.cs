using System.Collections.Generic;

namespace ShoppingCart.Models
{
    public class ProductList
    {
        #region Properties
        public int NoOfProducts
        {
            get;set;
        }
        public List<Product> ListOfProducts
        {
            get;
            set;
        }
        #endregion
    }
}
