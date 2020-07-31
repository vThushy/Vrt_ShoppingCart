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

        public void SendResetCode(string userName)
        {
            try
            {
                string toMail = _shoppingCartDbContext.Customers.FirstOrDefault(c => c.UserName == userName).Email;
                string resetCode = ResetCodeGen.ResetCodeGenerator(toMail);
                User resetUser = _shoppingCartDbContext.Users.FirstOrDefault(u => u.UserName == userName);
                resetUser.ResetCode = resetCode;
                _shoppingCartDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool ValidateResetCode(string userName, string userCode)
        {
            try
            {
                if (userName != null && userCode != null)
                {
                    string generatedCode = _shoppingCartDbContext.Users.FirstOrDefault(u => u.UserName == userName).ResetCode;
                    if (generatedCode == userCode)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
