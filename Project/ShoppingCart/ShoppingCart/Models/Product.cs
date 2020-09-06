using ShoppingCart.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Product
    {
        #region Properties
        public int Id { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public double Discount { get; set; }

        [Required]
        public double Price { get; set; }

        [StringLength(100)]
        public string DefaultImage { get; set; }

        [NotMapped]
        public string Size { get; set; }
        
        [NotMapped]
        public int BaseProduct { get; set; }
        #endregion
    }
}
