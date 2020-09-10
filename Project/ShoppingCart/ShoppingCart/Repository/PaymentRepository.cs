using Microsoft.VisualBasic;
using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        #region class variables
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        #endregion

        #region constructor
        public PaymentRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }
        #endregion

        #region methods
        public bool MakeAPayment(Payment payment)
        {
            try
            {
                if (payment != null)
                {
                    payment.Date = DateAndTime.Now;
                    _shoppingCartDbContext.Payments.Add(payment);
                    _shoppingCartDbContext.SaveChanges();
                    return true; //for the moment we will return true always since we are not implementing the payment gateway.
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public List<Payment> GetPaymentsByUser(string userName)
        {
            if (userName != null)
            {
                int[] orders = _shoppingCartDbContext.Orders.Where(o => o.UserName == userName).Select(o => o.Id).ToArray();
                return _shoppingCartDbContext.Payments.Where(p => orders.Contains(p.Id)).ToList();
            }
            return null;
        }
        #endregion
    }
}
