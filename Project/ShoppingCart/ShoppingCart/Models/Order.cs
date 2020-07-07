using ShoppingCart.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public double Discount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [EnumDataType(typeof(OrderStatus), ErrorMessage = "Order Status value doesn't exist within enum")]
        public OrderStatus OrderStatus { get; set;}

    }
}
