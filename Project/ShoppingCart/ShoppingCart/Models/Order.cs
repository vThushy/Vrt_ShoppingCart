using ShoppingCart.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Order
    {
        #region Properties
        public int Id { get; set; }
        
        [ForeignKey("Customer")]
        public string UserName { get; set; }

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

        public List<OrderDetail> OrderDetails { get; set; }
        #endregion
    }
}
