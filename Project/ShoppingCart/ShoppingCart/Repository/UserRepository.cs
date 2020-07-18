using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using ShoppingCart.Utility;
using System;
using System.Linq;


namespace ShoppingCart.Repository
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
            try
            {
            shoppingCartDbContext.Users.Add(user);
            shoppingCartDbContext.SaveChanges();
            }
          catch(Exception e)
            {
                throw e;
            }
        }

        public User GetUser(string userName)
        {
            try
            {
            var foundUser = shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == userName));
            if (foundUser == null)
            {
                return null;
            }
            return foundUser;
            }
          catch(Exception e)
            {
                throw e;
            }
        }
        public User VerifyUser(User user)
        {
            try
            {
            var foundUser = shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == user.UserName && u.Password == user.Password));
            if (foundUser == null)
            {
                return null;
            }
            return foundUser;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void ChangePassword(User user)
        {
            try
            {
            var foundUser = shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == user.UserName));
            foundUser.Password = Hashing.ConvertToHash(user.Password);
            shoppingCartDbContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void RemoveUser(User user)
        {
            try
            {
            shoppingCartDbContext.Remove(user);
            shoppingCartDbContext.SaveChanges();
            }
           catch(Exception e)
            {
                throw e;
            }
        }

        public void ForgotPassword()
        {
            throw new NotImplementedException();
        }
    }
}
