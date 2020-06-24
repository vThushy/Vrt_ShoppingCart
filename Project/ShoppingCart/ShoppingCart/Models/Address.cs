using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    /// <summary>
    /// Customer Address
    /// </summary>
    public class Address
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [EnumDataType(typeof(Type), ErrorMessage = "Address Type value doesn't exist within enum")]
        public Type AddressType { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressLine { get; set; }

        [Required]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        //[Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }
    }
}
