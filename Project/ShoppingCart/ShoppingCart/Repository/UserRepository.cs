using ShoppingCart.Contexts;
using ShoppingCart.Utility;
using System;
using System.Linq;


namespace ShoppingCart.Models.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly ShoppingCartDbContext shoppingCartDbContext;
        public UserRepository(ShoppingCartDbContext _shoppingCartDbContext)
        {
            shoppingCartDbContext = _shoppingCartDbContext;
        }

        public void AddUser(User user)
        {
            shoppingCartDbContext.Users.Add(user);
            shoppingCartDbContext.SaveChanges();
        }

        public User VerifyUser(User user)
        {
            string hashPassword = Hashing.ConvertToHash(user.Password);
            var foundUser = shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == user.UserName && u.Password == hashPassword));
            if (foundUser == null)
            {
                return null;
            }
            return foundUser;
        }

        public void ChangePassword(User user)
        {
            var foundUser = shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == user.UserName));
            foundUser.Password = Hashing.ConvertToHash(user.Password);
            shoppingCartDbContext.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            shoppingCartDbContext.Remove(user);
            shoppingCartDbContext.SaveChanges();
        }

        public void ForgotPassword()
        {
            throw new NotImplementedException();
        }
    }
}
