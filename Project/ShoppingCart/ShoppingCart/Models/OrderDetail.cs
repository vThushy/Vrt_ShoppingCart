using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class OrderDetail 
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        public int Id { get; set; }

        //[Required]
        //[Key]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        //[Required]
        //[Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 10)]
        [DataType(DataType.Currency)]
        public double UnitPrice { get; set; }

        [Required]
        [Range(1, 10)]
        public int Quantity { get; set; }
    }
}
