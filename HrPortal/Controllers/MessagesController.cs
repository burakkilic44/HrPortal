using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HrPortal.Models;
using HrPortal.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrPortal.Controllers
{
    public class MessagesController : Controller
    {


  
        private IRepository<Company> companyRepository;
        private IRepository<Resume> resumeRepository;
        private UserManager<ApplicationUser> userManager;
 


        public MessagesController(IRepository<Company> companyRepository, IRepository<Resume> resumeRepository, UserManager<ApplicationUser> userManager)
        {
            this.companyRepository = companyRepository;
            this.resumeRepository = resumeRepository;
            this.userManager = userManager;
        }

        // GET: /<controller>/
        [Route("Mesajlar/Mesajlarim")]
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult SendMessage(string subject, string message, string resumeid)
        {
            var usr = userManager.Users.FirstOrDefault(f => f.UserName == User.Identity.Name);
            var msg = new Message();
            msg.ApplicationUserId = usr.Id;
            msg.Subject = subject;
            msg.Body = message;
            msg.ResumeId = resumeid;
            msg.CompanyId = companyRepository.

            var recepientEmail = resumeRepository.Get(resumeid).Email;

            SmtpClient client = new SmtpClient("mail.bilisimkariyer.net");
            client.UseDefaultCredentials = false;
            client.EnableSsl = false;
            client.Port = 587;
            client.Credentials = new NetworkCredential("cvhavuzu@bilisimkariyer.net", "waa6hl");

            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("cvhavuzu@bilisimkariyer.net");
            mailMessage.To.Add(recepientEmail);
            mailMessage.Body = message;
            client.Send(mailMessage);

            return Json(true);
        }
    }
}
