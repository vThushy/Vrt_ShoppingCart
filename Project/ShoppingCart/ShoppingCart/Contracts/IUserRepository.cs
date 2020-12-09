using ShoppingCart.Models;
using System;

namespace ShoppingCart.Contracts
{
    public interface IUserRepository
    {
        #region contracts
        User AddUser(User user);
        bool VerifyUser(User user);
        Boolean ChangePassword(User user);
        User GetUser(string userName);
        Boolean RemoveUser(string userName);
        string SendResetCode(string userName);
        bool ValidateResetCode(string sysCode, string userCode);
        bool ValidUserName(string userName);
        #endregion
    }
}
