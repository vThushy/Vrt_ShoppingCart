using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Stock
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        public int Id { get; set; }

        //[Required]
        //[Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string InventoryLocation { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        [Required]
        [Range(0, 10)]
        public int Quantity { get; set; }
    }
}
