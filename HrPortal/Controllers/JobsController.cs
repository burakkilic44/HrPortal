using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrPortal.Controllers
{
    public class JobsController : Controller
    {
        private IRepository<Job> jobRepository;
        private IRepository<Company> companyRepository;
        private IRepository<Location> locationRepository;
        private IRepository<Resume> resumeRepository;
        public JobsController (IRepository<Job> jobRepository, IRepository<Company> companyRepository, IRepository<Location> locationRepository ,IRepository<Resume> resumeRepository)
        {
            this.resumeRepository = resumeRepository;
            this.jobRepository = jobRepository;
            this.companyRepository = companyRepository;
            this.locationRepository = locationRepository;
        }
        public IActionResult Index()
        {
            var jobs = jobRepository.GetAll("Company", "JobLocations", "JobLocations.Location");
            return View(jobs);

        }
        public IActionResult Create()
        {
            var job = new Job();
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(),"Id","Name");
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            return View(job);

          
        }
        [HttpPost]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                jobRepository.Insert(job);
                return RedirectToAction("SuccessfullyCreated");
            }
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            return View(job);
        }
        public IActionResult Details(string id)
        {
            var job = jobRepository.Get(id, "Company", "JobLocations", "JobLocations.Location");
            return View(job);
        }

    
        public IActionResult Apply(string id)
        {           
            var job = jobRepository.Get(id, "Company","JobLocations", "JobLocations.Location");
            ViewBag.Resumes = resumeRepository.GetMany(r => r.CreateBy == User.Identity.Name);
           

            return View(job);
        }
        
        public IActionResult SuccessfullyCreated()
        {
            return View();
        }
    }
}