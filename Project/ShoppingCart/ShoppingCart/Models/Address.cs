using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Address
    {
        #region Properties
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public string UserName { get; set; }

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
        #endregion
    }
}
