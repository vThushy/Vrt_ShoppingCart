using ShoppingCart.Contexts;
using ShoppingCart.Contracts;
using ShoppingCart.Models;
using ShoppingCart.Utility;
using System;
using System.Linq;


namespace ShoppingCart.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ShoppingCartDbContext _shoppingCartDbContext;


        public UserRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }



        public void AddUser(User user)
        {
            try
            {
                _shoppingCartDbContext.Users.Add(user);
                _shoppingCartDbContext.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }
        
        public User GetUser(string userName)
        {
            try
            {
                var foundUser = _shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == userName));
                if (foundUser == null)
                {
                    return null;
                }
                return foundUser;
            }
            catch
            {
                throw;
            }
        }
        
        public User VerifyUser(User user)
        {
            try
            {
                user.Password = Hashing.ConvertToHash(user.Password);
                var foundUser = _shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == user.UserName && u.Password == user.Password));
                if (foundUser == null)
                {
                    return null;
                }
                return foundUser;
            }
            catch
            {
                throw;
            }
        }
        
        public void ChangePassword(User user)
        {
            try
            {
                var foundUser = _shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == user.UserName));
                foundUser.Password = Hashing.ConvertToHash(user.Password);
                _shoppingCartDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void RemoveUser(User user)
        {
            try
            {
                _shoppingCartDbContext.Remove(user);
                _shoppingCartDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void ForgotPassword()
        {
            throw new NotImplementedException();
        }
    }
}
