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
        #region class variables
        private readonly ShoppingCartDbContext _shoppingCartDbContext;
        #endregion

        #region constructor
        public UserRepository(ShoppingCartDbContext shoppingCartDbContext)
        {
            _shoppingCartDbContext = shoppingCartDbContext;
        }
        #endregion

        #region methods
        public void AddUser(User user)
        {
            try
            {
                if (user != null)
                {
                    _shoppingCartDbContext.Users.Add(user);
                    _shoppingCartDbContext.SaveChanges();
                }
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
                if (userName != null)
                {
                    User foundUser = _shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == userName));
                    return foundUser;
                }
                return null;
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
                if (user != null)
                {
                    user.Password = Hashing.ConvertToHash(user.Password);
                    User foundUser = _shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == user.UserName && u.Password == user.Password));
                    return foundUser;
                }
                return null;
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
                if (user != null)
                {
                    var foundUser = _shoppingCartDbContext.Users.FirstOrDefault(u => (u.UserName == user.UserName));
                    foundUser.Password = Hashing.ConvertToHash(user.Password);
                    _shoppingCartDbContext.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public void RemoveUser(string userName)
        {
            try
            {
                if (userName != null)
                {
                    User user = _shoppingCartDbContext.Users.FirstOrDefault(u => u.UserName == userName);
                    _shoppingCartDbContext.Remove(user);
                    _shoppingCartDbContext.SaveChanges();
                }
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
        #endregion
    }
}
