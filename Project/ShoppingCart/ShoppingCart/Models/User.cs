using ShoppingCart.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class User
    {
        [Key]
        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [EnumDataType(typeof(AccessRole), ErrorMessage = "User Role value doesn't exist within enum")]
        public AccessRole UserRole { get; set; }
    }
}
