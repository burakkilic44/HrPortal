using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HrPortal.Services;

namespace HrPortal.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "mail adresini onayla",
                $"Üyeliði aktifleþtirmek için týklayýn: <a href='{HtmlEncoder.Default.Encode(link)}'><strong>link</strong></a>");
        }
    }
}
