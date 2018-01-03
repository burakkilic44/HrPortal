using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;

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
        private IUnitOfWork unitOfWork;



        public JobApplicationController( IRepository<EducationInfo> educationInfoRepository,IRepository<Company> companyRepository, IRepository<Location> locationRepository,IRepository<Occupation> occupationRepository,IRepository<Resume> resumeRepository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.companyRepository = companyRepository;
            this.locationRepository = locationRepository;
            this.resumeRepository = resumeRepository;
            this.occupationRepository = occupationRepository;
            this.educationInfoRepository = educationInfoRepository;
            this.jobApplicationRepository = unitOfWork.JobApplicationRepository;
            this.jobRepository = unitOfWork.JobRepository;
  
        }


        [Route("basvurularim")]
        public async Task<IActionResult> MyApplications(JobApplicationSearchViewModel jvm)
        {

            jvm.SearchResults = await jobApplicationRepository.GetPaged(s => s.CreatedBy == User.Identity.Name && (!String.IsNullOrEmpty(jvm.Keywords) ? s.Job.Title.Contains(jvm.Keywords) : true), o => o.Job.Title, false, 10, jvm.Page, "Job", "Resume","Job.Company","Resume.Location");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", jvm);
            return View(jvm);

        }


        [Route("basvurular")]
        public async Task<IActionResult> Applications(ApplicationSearchViewModel vm)
        {
            // iki context hatası
            var jobIds = jobRepository.GetMany(j => j.CreatedBy == User.Identity.Name).Select(s => s.Id);
            vm.SearchResults = await jobApplicationRepository.GetPaged(s =>  jobIds.Contains(s.JobId) && (!String.IsNullOrEmpty(vm.Keywords) ? s.Resume.FullName.Contains(vm.Keywords) : true) && (!String.IsNullOrEmpty(vm.LocationId) ? s.Resume.LocationId == vm.LocationId : true) && (vm.MilitaryStatus.HasValue ? s.Resume.MilitaryStatus == vm.MilitaryStatus : true) && (vm.EducationLevel.HasValue ? s.Resume.EducationInfos.Any(e => e.EducationLevel == vm.EducationLevel) : true), s => s.Resume.Title, false, 10, vm.Page, "Resume","Resume.Location");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", vm.LocationId);
            ViewBag.Occupations = new SelectList(occupationRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", vm.OccupationId);
            ViewBag.Jobs = new SelectList(jobRepository.GetAll().ToList(), "Id", "Title",vm.JobId);
            return View(vm);
        }


        public JsonResult SendMessage(string message, string resumeid)
        {
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





        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Delete(string id)
        {
            var jobApplication = jobApplicationRepository.GetMany(c => c.Id == id && (!User.IsInRole("Admin") ? c.CreatedBy == User.Identity.Name : true)).FirstOrDefault();

            if (jobApplication == null)
            {
                return NotFound();
            }
  
            jobApplicationRepository.Delete(jobApplication);
            return RedirectToAction("MyApplications");
        }

    }
}