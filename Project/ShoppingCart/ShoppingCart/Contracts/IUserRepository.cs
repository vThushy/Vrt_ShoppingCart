using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Contracts
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User VerifyUser(User user);
    }
}
