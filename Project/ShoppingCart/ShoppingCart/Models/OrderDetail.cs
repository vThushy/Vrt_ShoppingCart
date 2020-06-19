using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class OrderDetail 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
