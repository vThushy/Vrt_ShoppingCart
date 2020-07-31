using Microsoft.Extensions.Configuration;
using ShoppingCart.Models;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;

namespace ShoppingCart.Utility
{
    public class EMail
    {

        private IConfiguration _configuration;

        public EMail(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SmtpClient GetSmtp()
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = _configuration.GetValue<string>("MailConfiguration:Host");
                smtp.Port = _configuration.GetValue<int>("MailConfiguration:Port"); 
                smtp.EnableSsl = _configuration.GetValue<bool>("MailConfiguration:SSL"); 
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_configuration.GetValue<string>("MailConfiguration:UserName"),
                    _configuration.GetValue<string>("MailConfiguration:Password"));
                return smtp;
            }
            catch
            {
                throw;
            }
        }

        public void Send(MailContent mail)
        {
            try
            {
                if(mail != null)
                {
                    using (var message = new MailMessage(mail.ToEmail, mail.ToEmail))
                    {
                        message.Subject = mail.Subject;
                        message.Body = mail.Body;
                        message.IsBodyHtml = mail.IsHtml;
                        GetSmtp().Send(message);
                    }
                }
            }
            catch
            {
                throw;
            }
            
        }
    }

    public class MailConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
    }

  

}
