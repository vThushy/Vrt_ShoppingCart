using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public interface IUserRepository
    {
        User VerifyUser(User user);
    }
}
