using ShoppingCart.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class ProductDetails
    {
        #region Properties
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public string Color { get; set; }

        public ProductSize Size { get; set; }

        public string Attributes { get; set; }

        public string Image { get; set; }
        #endregion
    }
}
