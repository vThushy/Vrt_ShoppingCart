using ShoppingCart.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class User
    {
        //[Key]
        ////[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        [Required]
        [EnumDataType(typeof(Role), ErrorMessage = "User Role value doesn't exist within enum")]
        public Role UserRole { get; set; }
    }
}
