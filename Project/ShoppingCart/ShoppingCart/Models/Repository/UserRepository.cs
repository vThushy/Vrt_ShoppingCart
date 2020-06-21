using ShoppingCart.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;
        public UserRepository(ShoppingCartDbContext _shoppingCartDbContext)
        {
            shoppingCartDbContext = _shoppingCartDbContext;
        }

        public User VerifyUser(User _user)
        {
            var user = shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == _user.UserName && u.Password == _user.Password));
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
