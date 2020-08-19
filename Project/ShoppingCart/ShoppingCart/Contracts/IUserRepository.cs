using ShoppingCart.Models;

namespace ShoppingCart.Contracts
{
    public interface IUserRepository
    {
        #region contracts
        void AddUser(User user);
        bool VerifyUser(User user);
        void ChangePassword(User user);
        User GetUser(string userName);
        void RemoveUser(string userName);
        void SendResetCode(string userName);
        bool ValidateResetCode(string sysCode, string userCode);
        bool ValidUserName(string userName);
        #endregion
    }
}
