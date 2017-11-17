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
    public class JobApplicationController : Controller

    {


        private IRepository<Job> jobRepository;
        private IRepository<Company> companyRepository;
        private IRepository<Location> locationRepository;
        private IRepository<JobApplication> jobApplicationRepository;

        public JobApplicationController(IRepository<Job> jobRepository,IRepository<Company> companyRepository, IRepository<Location> locationRepository,IRepository<JobApplication> jobApplicationRepository)
        {
            this.jobRepository = jobRepository;
            this.companyRepository = companyRepository;
            this.locationRepository = locationRepository;
            this.jobApplicationRepository = jobApplicationRepository;
        }
  


        public async Task<IActionResult> MyApplications(JobApplicationSearchViewModel jvm)
        {

            jvm.SearchResults = await jobApplicationRepository.GetPaged(s => s.CreatedBy == User.Identity.Name && (!String.IsNullOrEmpty(jvm.Keywords) ? s.Job.Title.Contains(jvm.Keywords) : true), o => o.Job.Title, false, 10, jvm.Page, "Job", "Resume" );
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", jvm);
            return View(jvm);

        }



        public IActionResult Application()
        {
            return View();
        }

    }
}