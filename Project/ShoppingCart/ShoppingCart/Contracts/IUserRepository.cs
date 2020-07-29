using ShoppingCart.Models;

namespace ShoppingCart.Contracts
{
    public interface IUserRepository
    {
        #region contracts
        void AddUser(User user);
        User VerifyUser(User user);
        void ChangePassword(User user);
        User GetUser(string userName);
        void ForgotPassword();
        void RemoveUser(string userName);
        #endregion
    }
}
