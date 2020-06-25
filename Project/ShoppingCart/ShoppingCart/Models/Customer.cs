using ShoppingCart.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class Customer 
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        public int Id { get; set; } 

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        [Required]
        [EnumDataType(typeof(Gender),ErrorMessage ="Gender type doesn't exist within enum")]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(25)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
