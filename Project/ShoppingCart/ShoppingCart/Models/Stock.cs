using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string InventoryLocation { get; set; }
        public string Note { get; set; }
        public int Quantity { get; set; }
    }
}
