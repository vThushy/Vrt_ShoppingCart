using ShoppingCart.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Customer 
    {
        #region Properties
        [Key]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EnumDataType(typeof(Gender),ErrorMessage ="Gender type doesn't exist within enum")]
        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number.")]
        public string Phone { get; set; }

        [Required]
        [StringLength(25)]
        [EmailAddress]
        public string Email { get; set; }
        #endregion
    }
}
