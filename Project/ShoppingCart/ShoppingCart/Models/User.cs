using ShoppingCart.Enum;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class User
    {
        #region Properties
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
        #endregion
    }
}
