using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Models;
using HrPortal.Data;
using HrPortal.Services;
using Microsoft.AspNetCore.Identity;

namespace HrPortal.Controllers
{
    public class HomeController : Controller
    {
        
        private IRepository<Resume> resumeRepository;
        private IRepository<Message> messageRepository;
        private IRepository<Job> jobRepository;
   
        public HomeController(IRepository<Resume> resumeRepository, IRepository<Message> messageRepository, IRepository<Job> jobRepository)
        {
   
            this.resumeRepository = resumeRepository;
            this.messageRepository = messageRepository;
            this.jobRepository = jobRepository;
            
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.ResumeCount = resumeRepository.Count();
            ViewBag.jobCount = jobRepository.Count();
            ViewBag.jobs = jobRepository.GetAll("Company","JobLocations","JobLocations.Location");
            ViewBag.resumes = resumeRepository.GetAll("EducationInfos");
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Message message)
        {
            if (ModelState.IsValid) { 
            messageRepository.Insert(message);
            }
            return View(message);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
