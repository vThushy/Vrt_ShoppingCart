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
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required]
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
