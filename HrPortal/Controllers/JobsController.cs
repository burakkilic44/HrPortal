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
        private IRepository<JobApplication> jobApplicationRepository;
        public JobsController (IRepository<Job> jobRepository, IRepository<Company> companyRepository, IRepository<Location> locationRepository ,IRepository<Resume> resumeRepository, IRepository<JobApplication> jobApplicationRepository)
        {
            this.resumeRepository = resumeRepository;
            this.jobRepository = jobRepository;
            this.companyRepository = companyRepository;
            this.locationRepository = locationRepository;
            this.jobApplicationRepository = jobApplicationRepository;
        }
        public async Task<IActionResult> Index(JobSearchViewModel jvm)
        {
            
            jvm.SearchResults = await jobRepository.GetPaged(s => (!String.IsNullOrEmpty(jvm.Keywords) ? s.Title.Contains(jvm.Keywords) : true) && (!String.IsNullOrEmpty(jvm.LocationId) ? s.JobLocations.Any(l=> l.LocationId == jvm.LocationId) : true) && (jvm.MilitaryStatus.HasValue ? s.MilitaryStatus == jvm.MilitaryStatus : true) && (jvm.EducationLevel.HasValue ? s.EducationInfos.Any(e => e.EducationLevel == jvm.EducationLevel) : true)&& (jvm.WorkingStyle.HasValue ? s.WorkingStyle == jvm.WorkingStyle : true),o=>o.Title,false,10,jvm.Page, "Company", "JobLocations", "JobLocations.Location");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", jvm.LocationId);
            return View(jvm);

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
        [HttpPost]
        public IActionResult Apply(JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
              jobApplicationRepository.Insert(jobApplication);
              return RedirectToAction("SuccessfullyApplication");

            }
            return View(jobApplication);
        }


        public IActionResult SuccessfullyCreated()
        {
            return View();
        }

        public IActionResult SuccessfullyApplication()
        {
            return View();
        }
    }
}