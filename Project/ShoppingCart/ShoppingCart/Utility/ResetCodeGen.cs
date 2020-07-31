using ShoppingCart.Models;
using System;

namespace ShoppingCart.Utility
{
    public static class ResetCodeGen
    {
        public static string ResetCodeGenerator(string toMail)
        {
            try
            {
                if (toMail != null)
                {
                    
                    MailContent mail = new MailContent();
                    mail.ToEmail = toMail;
                    mail.IsHtml = false;
                    mail.Subject = "Password recovery";
                    mail.Body = "Please enter the below code to reset the password! \n";
                    Random generator = new Random();
                    string resetCode = generator.Next(0, 999999).ToString("D6");
                    mail.Body += resetCode;
                    return resetCode;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }
    }
}
