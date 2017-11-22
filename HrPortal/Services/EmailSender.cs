using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HrPortal.Services
{
    //This class is used by the application to send email for account confirmation and password reset.
    //For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {


            SmtpClient client = new SmtpClient("mail.bilisimkariyer.net");
            client.UseDefaultCredentials = false;
            client.EnableSsl = false;
            client.Port = 587;
            client.Credentials = new NetworkCredential("cvhavuzu@bilisimkariyer.net", "waa6hl");

            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("cvhavuzu@bilisimkariyer.net");
            mailMessage.To.Add(email);
            mailMessage.Body = message;
            mailMessage.Subject = subject;
            client.Send(mailMessage);
            return Task.CompletedTask;
           
        }
}
}
