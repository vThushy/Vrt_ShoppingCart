using ShoppingCart.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Payment
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        public int Id { get; set; }

        //[Required]
        //[Key]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required]
        [EnumDataType(typeof(Method), ErrorMessage = "Payment Method value doesn't exist within enum")]
        public Method Method { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        [Required]
        [Range(1, 10)]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
