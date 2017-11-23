using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;

namespace HrPortal.Controllers
{
    public class ResumesController : Controller
    {
        
        private IRepository<Resume> resumeRepository;
        private IRepository<Location> locationRepository;
        private IRepository<Language> languageRepository;
        private IRepository<EducationInfo> educationInfoRepository;
        private IRepository<Experience> experienceRepository;
        private IRepository<Skill> skillRepository;
        private IRepository<Certificate> certificateRepository;
        private IRepository<Occupation> occupationRepository;
        private IRepository<Tag> tagRepository;
        private IRepository<LanguageInfo> languageInfoRepository;




        public ResumesController(IRepository<Resume> resumeRepository, IRepository<Location> locationRepository, IRepository<Language> languageRepository, IRepository<EducationInfo> educationInfoRepository, IRepository<Experience> experienceRepository, IRepository<Skill> skillRepository, IRepository<Certificate> certificateRepository, IRepository<Tag> tagRepository, IRepository<LanguageInfo> languageInfoRepository, IRepository<Occupation> occupationRepository)
        {
            this.languageInfoRepository=languageInfoRepository;
            this.tagRepository = tagRepository;
            this.languageRepository = languageRepository;
            this.locationRepository = locationRepository;
            this.resumeRepository = resumeRepository;
            this.educationInfoRepository = educationInfoRepository;
            this.experienceRepository = experienceRepository;
            this.skillRepository = skillRepository;
            this.certificateRepository = certificateRepository;
            this.occupationRepository = occupationRepository;
            

        }
        [Authorize(Roles = "Employer,Admin")]
        public async Task<IActionResult> Index(ResumeSearchViewModel vm)
        {
            vm.SearchResults = await resumeRepository.GetPaged(s => (!String.IsNullOrEmpty(vm.Keywords) ? s.FullName.Contains(vm.Keywords) : true) && (!String.IsNullOrEmpty(vm.LocationId) ? s.LocationId == vm.LocationId : true) && (vm.MilitaryStatus.HasValue ? s.MilitaryStatus == vm.MilitaryStatus : true) && (vm.EducationLevel.HasValue ? s.EducationInfos.Any(e => e.EducationLevel == vm.EducationLevel) : true), s => (vm.SortBy == 1 || vm.SortBy == 2 ? s.FullName:(vm.SortBy==3 || vm.SortBy==4 ? s.Occupation.Name:(vm.SortBy==5 ||vm.SortBy==6 ? s.Location.Name:s.UpdateDate.ToString()))),(vm.SortBy==1 || vm.SortBy ==3 || vm.SortBy == 5?false:(vm.SortBy == 2 || vm.SortBy ==4 || vm.SortBy == 6 )), 2, vm.Page, "EducationInfos", "Location");
            vm.SearchResults.RouteValue = new RouteValueDictionary { { "Keywords", vm.Keywords }, { "LocationId", vm.LocationId }, { "MilitaryStatus", vm.MilitaryStatus }, { "EducationLevel", vm.EducationLevel }, { "SortBy", vm.SortBy } };
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id","Name", vm.LocationId);
            ViewBag.Occupations = new SelectList(occupationRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", vm.OccupationId);
            return View(vm);
        }
        
        public IActionResult Details(string id)
        {
            var resume = resumeRepository.GetMany(c => c.Id == id && (!User.IsInRole("Admin") ? c.CreatedBy == User.Identity.Name : true), "EducationInfos", "Experiences", "Skills", "Certificates", "LanguageInfos", "Language", "Location").FirstOrDefault();
            if (resume == null)
            {
                return NotFound();
            }
           
            return View(resume);
        }
        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult Create()
        {
            var resume = new Resume();
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(tagRepository.GetAll().OrderBy(t => t.Name).ToList(), "Id", "Name");
            return View(resume);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public IActionResult Create(Resume resume)
        {
            if (ModelState.IsValid)
            {
                resumeRepository.Insert(resume);
            }
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(tagRepository.GetAll().OrderBy(t => t.Name).ToList(), "Id", "Name");
            ViewBag.IsModelStateValid = ModelState.IsValid;
            return View(resume);
        }

        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult Edit(string id)
                    {
            // privent to any user to edit
            var resume = resumeRepository.GetMany(r => r.Id == id && (!User.IsInRole("Admin") ? r.CreatedBy == User.Identity.Name : true)).FirstOrDefault();
            if (resume == null)
            {
                return NotFound();
            }
            
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(tagRepository.GetAll().OrderBy(t => t.Name).ToList(), "Id", "Name");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            return View(resume);
        }

        [HttpPost]
        public IActionResult Edit(Resume resume)
        {
            {
                if (!User.IsInRole("Admin") && resume.CreatedBy != User.Identity.Name)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    resumeRepository.Update(resume);
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(tagRepository.GetAll().OrderBy(t => t.Name).ToList(), "Id", "Name");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            return View(resume);
        }

        public IActionResult Delete(string id)
        {
            var resume = resumeRepository.GetMany(r => r.Id == id && (!User.IsInRole("Admin") ? r.CreatedBy == User.Identity.Name : true)).FirstOrDefault();
            if (resume == null)
            {
                return NotFound();
            }
            educationInfoRepository.Delete(e => e.ResumeId == id);
            experienceRepository.Delete(e => e.ResumeId == id);
            skillRepository.Delete(e => e.ResumeId == id);
            certificateRepository.Delete(e => e.ResumeId == id);
            languageInfoRepository.Delete(e => e.ResumeId == id);
            resumeRepository.Delete(r => r.Id == id);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult EducationInfoCreate()
        {
            var EducationInfo = new EducationInfo();
            return View(EducationInfo);
        }

        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult EducationInfoCreate(EducationInfo educationinfo) 
        {
            if (ModelState.IsValid)
            {
                educationInfoRepository.Insert(educationinfo);
            }
            return Json("Success");
        }
        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult EducationInfoEdit(string ResumeId) 
        {           
            var educationinfo = educationInfoRepository.GetAll().Where(r => r.ResumeId == ResumeId);
            return View(educationinfo);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult EducationInfoEdit(EducationInfo educationinfo) 
        {
            if (ModelState.IsValid)
            {
                educationInfoRepository.Update(educationinfo);
            }
            return Json("Success");
        }


        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult ExperienceCreate() 
        {
            var Experience = new Experience();
            return View(Experience);
        }

        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult ExperienceCreate(Experience experience)
        {
            if (ModelState.IsValid)
            {
                experienceRepository.Insert(experience);
            }
            return Json("Success");
        }
       
        
        public IActionResult ExperienceEdit(string ResumeId) 
        {
            var experience = experienceRepository.GetAll().Where(r => r.ResumeId == ResumeId);
            return View(experience);
        }

        
        [HttpPost]
        public JsonResult ExperienceEdit(Experience experience) 
        {
            if (ModelState.IsValid)
            {
                experienceRepository.Update(experience);
            }
            return Json("Success");
        }

        [HttpPost]
        public JsonResult ExperienceDelete(string ResumeId)
        {
            var experience = experienceRepository.Get(ResumeId);
            experienceRepository.Delete(experience);
            return Json("Success");
            
        }


        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult SkillCreate() 
        {
            var Skill = new Skill();
            return View(Skill);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult SkillCreate(Skill skill) 
        {
            if (ModelState.IsValid)
            {
               skillRepository.Insert(skill);
            }
            return Json("Success");
        }
       
        public IActionResult SkillEdit(string ResumeId) 
        {
            var skill = skillRepository.GetAll().Where(r => r.ResumeId == ResumeId);
            return View(skill);
        }
        
        [HttpPost]
        public JsonResult SkillEdit(Skill skill) 
        {
            if (ModelState.IsValid)
            {
                skillRepository.Update(skill);
            }
            return Json("Success");
        }


        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult CertificateCreate()  
        {
            var Certificate = new Certificate();
            return View(Certificate);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult CertificateCreate(Certificate certificate) 
        {
            if (ModelState.IsValid)
            {
                certificateRepository.Insert(certificate);
            }
            return Json("Success");
        }

        
        public IActionResult CertificateEdit(string ResumeId) 
        {
            var certificate = certificateRepository.GetAll().Where(r => r.ResumeId == ResumeId);
            return View(certificate);
        }
        
        [HttpPost]
        public JsonResult CertificateEdit(Certificate certificate) 
        {
            if (ModelState.IsValid)
            {
                certificateRepository.Update(certificate);
            }
            return Json("Success");
        }


        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult LanguageInfoCreate() 
        {
            var LanguageInfo = new LanguageInfo();
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            return View(LanguageInfo);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult LanguageInfoCreate(LanguageInfo languageinfo) 
        {
            if (ModelState.IsValid)
            {
                languageInfoRepository.Insert(languageinfo);
            }
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            return Json("Success");      
        }

       
        public IActionResult LanguageInfoEdit(string ResumeId) 
        {
            var languageinfo = languageInfoRepository.GetAll().Where(r => r.ResumeId == ResumeId);
            return View(languageinfo);
        }
       
        [HttpPost]
        public JsonResult LanguageInfoEdit(LanguageInfo languageInfo) 
        {
            if (ModelState.IsValid)
            {
                languageInfoRepository.Update(languageInfo);
            }
            return Json("Success");
        }

        [Authorize(Roles = "Candidate,Admin")]
        public ActionResult TagHelper(string term) //Etiket yardımcısı
        {
            
            var data = tagRepository.GetAll().Select(s => new {id=s.Id, name=s.Name}).Take(10).ToList();
            return Json(data);
        }

        public async Task<IActionResult> MyResumes(ResumeSearchViewModel vm)
        {
            vm.SearchResults = await resumeRepository.GetPaged(s => s.CreatedBy == User.Identity.Name && (!String.IsNullOrEmpty(vm.Keywords) ? s.FullName.Contains(vm.Keywords) : true) && (!String.IsNullOrEmpty(vm.LocationId) ? s.LocationId == vm.LocationId : true) && (vm.MilitaryStatus.HasValue ? s.MilitaryStatus == vm.MilitaryStatus : true) && (vm.EducationLevel.HasValue ? s.EducationInfos.Any(e => e.EducationLevel == vm.EducationLevel) : true), s => s.Title, false, 10, vm.Page, "EducationInfos", "Location");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", vm.LocationId);
            ViewBag.Occupations = new SelectList(occupationRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", vm.OccupationId);
            return View(vm);
        }
    }
}