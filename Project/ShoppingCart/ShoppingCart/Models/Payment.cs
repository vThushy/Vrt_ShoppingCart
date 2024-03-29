﻿using ShoppingCart.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingCart.Models
{
    public class Payment
    {
        #region Properties
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [Required]
        [EnumDataType(typeof(PaymentMethod), ErrorMessage = "Payment Method value doesn't exist within enum")]
        public PaymentMethod PayMethod { get; set; }

        [StringLength(250)]
        public string Note { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        #endregion
    }
}
