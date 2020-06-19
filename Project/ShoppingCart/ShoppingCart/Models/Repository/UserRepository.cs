using ShoppingCart.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public class UserRepository
    {
        private readonly UserDbContext userDbContext;
        public UserRepository(UserDbContext _userDbContext)
        {
            userDbContext = _userDbContext;
        }

        public bool VerifyUser(string userName, string password)
        {
            var user = userDbContext.Users.FirstOrDefault(u => (u.UserName == userName && u.Password == password));
            if (user == null)
            {
                return false;
            }
            return true;
        }
    }
}
