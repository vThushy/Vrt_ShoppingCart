using ShoppingCart.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class User
    {
        //[Key]
        [Required]
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
