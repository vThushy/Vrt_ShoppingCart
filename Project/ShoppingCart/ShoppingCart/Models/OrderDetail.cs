using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class OrderDetail
    {
        #region Properties
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("ProductDetails")]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 10)]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        [Required]
        [Range(1, 10)]
        public int Quantity { get; set; }

       public Order Order { get; set; }
        #endregion
    }
}
