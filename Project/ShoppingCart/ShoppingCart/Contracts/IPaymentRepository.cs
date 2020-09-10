using ShoppingCart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Contracts
{
    public interface IPaymentRepository
    {
        #region contracts
        bool MakeAPayment(Payment payment);
        List<Payment> GetPaymentsByUser(string userName);
        #endregion
    }
}
