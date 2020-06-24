using ShoppingCart.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class Order
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        [Required]
        [Range(1, 5)]
        //[DataType(DataType.Currency)]
        public double Discount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [EnumDataType(typeof(Status), ErrorMessage = "Order Status value doesn't exist within enum")]
        public Status Status { get; set;}


    }
}
