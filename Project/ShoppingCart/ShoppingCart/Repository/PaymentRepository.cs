using Microsoft.VisualBasic;
using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;

namespace ShoppingCart.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ShoppingCartDbContext _shoppingCartDbContext;

        public PaymentRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }

        public bool MakeAPayment(Payment payment)
        {
            try
            {
                if(payment != null)
                {
                    payment.Date = DateAndTime.Now;
                    _shoppingCartDbContext.Payments.Add(payment);
                    _shoppingCartDbContext.SaveChanges();
                    return true; //for the moment we will return true always since we are not implementing the payment gateway.
                }
                throw new Exception("Payment object is null");
            }
            catch
            {
                throw;
            }
        }




    }
}
