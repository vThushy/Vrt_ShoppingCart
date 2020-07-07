using ShoppingCart.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    /// <summary>
    /// Customer Address
    /// </summary>
    public class Address
    {
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(20)]
        public string AddressType { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressLine { get; set; }

        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
    }
}
