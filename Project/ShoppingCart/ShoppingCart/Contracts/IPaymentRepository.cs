using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface IPaymentRepository
    {
        #region contracts
        bool MakeAPayment(Payment payment);
        #endregion
    }
}
