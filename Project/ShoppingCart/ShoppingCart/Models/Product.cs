using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Discount { get; set; }

        public float Price { get; set; }

        public string Image { get; set; }
    }
}
