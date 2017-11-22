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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrPortal.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Setting> settingRepository;
        private IRepository<Resume> resumeRepository;
        private IRepository<Message> messageRepository;
        private IRepository<Job> jobRepository;
        private IRepository<Location> locationRepository;

        public HomeController(IRepository<Resume> resumeRepository, IRepository<Message> messageRepository, IRepository<Job> jobRepository, IRepository<Location> locationRepository, IRepository<Setting> settingRepository)
        {
            this.settingRepository = settingRepository;
            this.resumeRepository = resumeRepository;
            this.messageRepository = messageRepository;
            this.jobRepository = jobRepository;
            this.locationRepository = locationRepository;
            

        }
        public IActionResult Index()
        {
            ViewBag.ResumeCount = resumeRepository.Count();
            ViewBag.jobCount = jobRepository.Count();
            ViewBag.jobs = jobRepository.GetAll("Company","JobLocations","JobLocations.Location");
            ViewBag.resumes = resumeRepository.GetAll("EducationInfos");
            ViewBag.Locations = locationRepository.GetAll();
            return View();
        }

        public IActionResult About()
        {
            var setting = settingRepository.GetAll().FirstOrDefault();

            return View(setting);
        }

        public IActionResult HowItWorks()
        {
            var setting = settingRepository.GetAll().FirstOrDefault();

            return View(setting);
        }
        public IActionResult Help()
        {
            var setting = settingRepository.GetAll().FirstOrDefault();

            return View(setting);
        }
        public IActionResult PrivacyPolicy()
        {
            var setting = settingRepository.GetAll().FirstOrDefault();

            return View(setting);
        }

        public IActionResult Contact()
        {
            var setting = settingRepository.GetAll().FirstOrDefault();
            
            return View(setting);
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
