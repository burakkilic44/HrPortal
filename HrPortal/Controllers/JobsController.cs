using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;

namespace HrPortal.Controllers
{
    public class JobsController : Controller
    {
        private IRepository<Job> jobRepository;
        private IRepository<Company> companyRepository;
        private IRepository<Location> locationRepository;
        private IRepository<Resume> resumeRepository;
        private IRepository<JobApplication> jobApplicationRepository;
        private IRepository<Occupation> occupationRepository;
        private object context;

        public JobsController (IRepository<Job> jobRepository, IRepository<Company> companyRepository, IRepository<Location> locationRepository ,IRepository<Resume> resumeRepository, IRepository<JobApplication> jobApplicationRepository, IRepository<Occupation> occupationRepository)
        {
            this.resumeRepository = resumeRepository;
            this.jobRepository = jobRepository;
            this.companyRepository = companyRepository;
            this.locationRepository = locationRepository;
            this.jobApplicationRepository = jobApplicationRepository;
            this.occupationRepository = occupationRepository;
        }
        public async Task<IActionResult> Index(JobSearchViewModel jvm)
        {
            
            jvm.SearchResults = await jobRepository.GetPaged(s => s.IsActive == true && s.PublishDate<=DateTime.Now && DateTime.Now<=s.EndDate&&(!String.IsNullOrEmpty(jvm.Keywords) ? s.Title.Contains(jvm.Keywords) : true) && (!String.IsNullOrEmpty(jvm.LocationId) ? s.JobLocations.Any(l=> l.LocationId == jvm.LocationId) : true) && (jvm.MilitaryStatus.HasValue ? s.MilitaryStatus == jvm.MilitaryStatus : true) && (jvm.EducationLevel.HasValue ? s.EducationLevel == jvm.EducationLevel : true)&& (jvm.WorkingStyle.HasValue ? s.WorkingStyle == jvm.WorkingStyle : true), s => (jvm.SortBy == 1 || jvm.SortBy == 2 ? s.Title : (jvm.SortBy == 3 || jvm.SortBy == 4 ? s.Occupation.Name : (jvm.SortBy == 5 || jvm.SortBy == 6 ? s.Company.LocationId: s.UpdateDate.ToString()))), (jvm.SortBy == 1 || jvm.SortBy == 3 || jvm.SortBy == 5 ? false : (jvm.SortBy == 2 || jvm.SortBy == 4 || jvm.SortBy == 6)),5,jvm.Page, "Company", "JobLocations", "JobLocations.Location");
            jvm.SearchResults.RouteValue = new RouteValueDictionary { { "keywords", jvm.Keywords }, { "locationId", jvm.LocationId }, { "sortBy", jvm.SortBy }, { "militaryStatus", jvm.MilitaryStatus }, { "educationLevel", jvm.EducationLevel }, { "workingStyle", jvm.WorkingStyle } };
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", jvm.LocationId);
            ViewBag.Occupations = new SelectList(occupationRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", jvm.OccupationId);
            return View(jvm);

        }
        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Create()
        {
            var job = new Job();
            ViewBag.Companies = new SelectList(companyRepository.GetMany(r => r.CreatedBy == User.Identity.Name).OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
           
            return View(job);


        }
        [HttpPost]
        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                job.EndDate = job.PublishDate.AddDays(60);
                job.JobLocations = new HashSet<JobLocation>();
                jobRepository.Insert(job);
                foreach (var item in job.LocationId)
                {
                    job.JobLocations.Add(new JobLocation() { JobId = job.Id, LocationId = item });
                    
                }
                jobRepository.Update(job);
                return RedirectToAction("SuccessfullyCreated");
            }
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            return View(job);
        }
        
        public IActionResult Details(string id)
        {
            var job = jobRepository.Get(id, "Company", "JobLocations", "JobLocations.Location");
            ViewBag.PublishAgoFormat = DisplayAgoFormat(job.PublishDate);
            return View(job);
           
        }

        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult Apply(string id)
        {
            var jobApplication = new JobApplication() { JobId = id,Job = jobRepository.Get(id, "JobLocations", "JobLocations.Location", "Company") };
            ViewBag.Resumes = resumeRepository.GetMany(r => r.CreatedBy == User.Identity.Name && r.IsActive == true && r.IsApproved == true,  "Location");
            return View(jobApplication);
        }

        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
       
        public IActionResult Apply(JobApplication jobApplication)
        {
            var oldJobApplication = jobApplicationRepository.Get(j => j.JobId == jobApplication.JobId && j.CreatedBy == User.Identity.Name);
            if (oldJobApplication != null) // kayıt dönerse daha önce başvurmuş demektir
            {
                ModelState.AddModelError("DuplicateRecord", "Bu ilana daha önce başvurmuştunuz.");
            }
            else if (ModelState.IsValid)
            {                
                jobApplicationRepository.Insert(jobApplication);
                return RedirectToAction("SuccessfullyApplication");

            }
            ViewBag.Resumes = resumeRepository.GetMany(r => r.CreatedBy == User.Identity.Name && r.IsActive == true && r.IsApproved == true, "Location");
            return View(jobApplication);
        }

        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Edit(string id)
        {
            var job = jobRepository.GetMany(j => j.Id == id && (!User.IsInRole("Admin") ? j.CreatedBy == User.Identity.Name : true), "JobLocations").FirstOrDefault();
            if (job == null)
            {
                return NotFound();
            }
    
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            job.LocationId = job.JobLocations.Select(s => s.LocationId).ToArray();
            return View(job);
        }
        [HttpPost]
        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Edit(Job job)
        {

            if (!(User.IsInRole("Employer") && job.CreatedBy == User.Identity.Name) || User.IsInRole("Admin"))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                job.EndDate = job.PublishDate.AddDays(60);

                var j = jobRepository.Get(job.Id, "JobLocations");
                j.JobLocations.Clear();
                jobRepository.Update(j);
              
                    foreach (var item in job.LocationId)
                    {
                        j.JobLocations.Add(new JobLocation() { JobId = job.Id, LocationId = item });
                      
                    }
                j.Title = job.Title;
                j.CompanyId = job.CompanyId;
                j.ShortDescription = job.ShortDescription;
                j.LocationId = job.LocationId;
                j.WorkingStyle = job.WorkingStyle;
                j.WorkingHours = job.WorkingHours;
                j.Experience = job.Experience;
                j.MilitaryStatus = job.MilitaryStatus;
                j.EducationLevel = job.EducationLevel;
                j.Details = job.Details;
                j.IsActive = job.IsActive;
                j.PublishDate = job.PublishDate;
                j.EndDate = job.EndDate;

                jobRepository.Update(j);
               
                

                return RedirectToAction("myAdsAsync");
            }
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            
            return View(job);
        }

        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Delete(string id)
        {
            var job = jobRepository.GetMany(c => c.Id == id && (!User.IsInRole("Admin") ? c.CreatedBy == User.Identity.Name : true)).FirstOrDefault();

            if (job == null)
            {
                return NotFound();
            }
           
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            jobRepository.Delete(job);
            return RedirectToAction("index");
        }
        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Remove(string id)
        {
            var job = jobRepository.GetMany(c => c.Id == id && (!User.IsInRole("Admin") ? c.CreatedBy == User.Identity.Name : true)).FirstOrDefault();

            if (job == null)
            {
                return NotFound();
            }
            job.IsActive = false;
            jobRepository.Update(job);
         
            return RedirectToAction("Index");
        }
        public IActionResult SuccessfullyCreated()
        {
            return View();
        }


        public async Task<IActionResult> myAdsAsync(JobSearchViewModel jvm)
        {

            jvm.SearchResults = await jobRepository.GetPaged(s => s.CreatedBy == User.Identity.Name && (!String.IsNullOrEmpty(jvm.Keywords) ? s.Title.Contains(jvm.Keywords) : true) && (!String.IsNullOrEmpty(jvm.LocationId) ? s.JobLocations.Any(l => l.LocationId == jvm.LocationId) : true) && (!String.IsNullOrEmpty(jvm.OccupationId) ? s.OccupationId == jvm.OccupationId : true) && (jvm.MilitaryStatus.HasValue ? s.MilitaryStatus == jvm.MilitaryStatus : true) && (jvm.EducationLevel.HasValue ? s.EducationLevel == jvm.EducationLevel : true) && (jvm.WorkingStyle.HasValue ? s.WorkingStyle == jvm.WorkingStyle : true), s => (jvm.SortBy == 1 || jvm.SortBy == 2 ? s.Title : (jvm.SortBy == 3 || jvm.SortBy == 4 ? s.Occupation.Name : s.UpdateDate.ToString())), (jvm.SortBy == 1 || jvm.SortBy == 3 || jvm.SortBy == 5 ? false : (jvm.SortBy == 2 || jvm.SortBy == 4 || jvm.SortBy == 6)), 10, jvm.Page, "Company", "JobLocations", "JobLocations.Location");


            return View(jvm);

        }


        public IActionResult SuccessfullyApplication()
        {
            return View();
        }

        
       static string DisplayAgoFormat(DateTime inputDate)
       {
            DateTime date =DateTime.Today;
            TimeSpan interval = date - inputDate;
            if (date == inputDate)
            {
                string result = "Bugün";
                return result;
            }
            else
            {
                string result1 = " gün önce";
                return interval.TotalDays.ToString() + result1;
            }
            
       
       }
        

    }
}