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
        private IRepository<Occupation> occupationRepository;
        private IRepository<EducationInfo> educationInfoRepository;
        private IRepository<Resume> resumeRepository;
        



        public JobApplicationController( IRepository<EducationInfo> educationInfoRepository,IRepository<Job> jobRepository,IRepository<Company> companyRepository, IRepository<Location> locationRepository,IRepository<JobApplication> jobApplicationRepository, IRepository<Occupation> occupationRepository,IRepository<Resume> resumeRepository)
        {
            this.jobRepository = jobRepository;
            this.companyRepository = companyRepository;
            this.locationRepository = locationRepository;
            this.jobApplicationRepository = jobApplicationRepository;
            this.resumeRepository = resumeRepository;
            this.occupationRepository = occupationRepository;
            this.educationInfoRepository = educationInfoRepository;
  
        }
  


        public async Task<IActionResult> MyApplications(JobApplicationSearchViewModel jvm)
        {

            jvm.SearchResults = await jobApplicationRepository.GetPaged(s => s.CreatedBy == User.Identity.Name && (!String.IsNullOrEmpty(jvm.Keywords) ? s.Job.Title.Contains(jvm.Keywords) : true), o => o.Job.Title, false, 10, jvm.Page, "Job", "Resume","Job.Company","Resume.Location");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", jvm);
            return View(jvm);

        }



        public async Task<IActionResult> Applications(ApplicationSearchViewModel vm)
        {
            vm.SearchResults = await jobApplicationRepository.GetPaged(s => s.CreatedBy == User.Identity.Name && (!String.IsNullOrEmpty(vm.Keywords) ? s.Resume.FullName.Contains(vm.Keywords) : true) && (!String.IsNullOrEmpty(vm.LocationId) ? s.Resume.LocationId == vm.LocationId : true) && (vm.MilitaryStatus.HasValue ? s.Resume.MilitaryStatus == vm.MilitaryStatus : true) && (vm.EducationLevel.HasValue ? s.Resume.EducationInfos.Any(e => e.EducationLevel == vm.EducationLevel) : true), s => s.Resume.Title, false, 10, vm.Page, "Resume","Resume.Location");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", vm.LocationId);
            ViewBag.Occupations = new SelectList(occupationRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", vm.OccupationId);
            ViewBag.Jobs = new SelectList(jobRepository.GetAll().ToList(), "Id", "Name");
            return View(vm);
        }

    }
}