using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<IActionResult> Index(ResumeSearchViewModel vm)
        {
            vm.SearchResults = await resumeRepository.GetPaged(s => (!String.IsNullOrEmpty(vm.Keywords) ? s.FullName.Contains(vm.Keywords) : true) && (!String.IsNullOrEmpty(vm.LocationId) ? s.LocationId == vm.LocationId : true) && (vm.MilitaryStatus.HasValue ? s.MilitaryStatus == vm.MilitaryStatus : true) && (vm.EducationLevel.HasValue ? s.EducationInfos.Any(e => e.EducationLevel == vm.EducationLevel) : true), s => (vm.SortBy == 1 || vm.SortBy == 2 ? s.FullName:(vm.SortBy==3 || vm.SortBy==4 ? s.Occupation.Name:(vm.SortBy==5 ||vm.SortBy==6 ? s.Location.Name:s.UpdateDate.ToString()))),(vm.SortBy==1 || vm.SortBy ==3 || vm.SortBy == 5?false:(vm.SortBy == 2 || vm.SortBy ==4 || vm.SortBy == 6 )), 10, vm.Page, "EducationInfos", "Location", "ResumeTags", "ResumeTags.Tag");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id","Name", vm.LocationId);
            ViewBag.Occupations = new SelectList(occupationRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", vm.OccupationId);
            return View(vm);
        }

        public IActionResult Details(string id)
        {
            var resume = resumeRepository.Get(id,"ResumeTags","ResumeTags.Tag","EducationInfos","Experiences","Skills","Certificates","LanguageInfos","Language","Location");
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
        public IActionResult Edit()
        {
            return View();
        }


        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult EducationInfos()
        {
            var EducationInfo = new EducationInfo();
            return View(EducationInfo);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult AddEducationInfo(EducationInfo educationinfo)
        {
            if (ModelState.IsValid)
            {
                educationInfoRepository.Insert(educationinfo);
            }
            return Json("Success");
        }
        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult Experience()
        {
            
            var Experience = new Experience();
            return View(Experience);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult AddExperience(Experience experience)
        {
            if (ModelState.IsValid)
            {
                experienceRepository.Insert(experience);
            }
            return Json("Success");
        }
        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult Skill()
        {
            var Skill = new Skill();
            return View(Skill);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult AddSkill(Skill skill)
        {
            if (ModelState.IsValid)
            {
               skillRepository.Insert(skill);
            }
            return Json("Success");
        }
        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult Certificate()
        {
            var Certificate = new Certificate();
            return View(Certificate);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult AddCertificate(Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                certificateRepository.Insert(certificate);
            }
            return Json("Success");
        }
        [Authorize(Roles = "Candidate,Admin")]
        public IActionResult LanguageInfos()
        {
            var LanguageInfo = new LanguageInfo();
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            return View(LanguageInfo);
        }
        [Authorize(Roles = "Candidate,Admin")]
        [HttpPost]
        public JsonResult AddLanguageInfo(LanguageInfo languageinfo)
        {
            if (ModelState.IsValid)
            {
                languageInfoRepository.Insert(languageinfo);
            }
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            return Json("Success");      
        }


        public IActionResult TagHelper(string term)
        [Authorize(Roles = "Candidate,Admin")]
        public ActionResult TagHelper(string term)
        {
          
            var data = tagRepository.GetMany(t => t.Name.StartsWith(term)).Select(s => new {id=s.Id, name=s.Name}).Take(10).ToList();
            return Json(data);
        }

        public async Task<IActionResult> MyResumes(ResumeSearchViewModel vm)
        {
            vm.SearchResults = await resumeRepository.GetPaged(s => s.CreatedBy == User.Identity.Name && (!String.IsNullOrEmpty(vm.Keywords) ? s.FullName.Contains(vm.Keywords) : true) && (!String.IsNullOrEmpty(vm.LocationId) ? s.LocationId == vm.LocationId : true) && (vm.MilitaryStatus.HasValue ? s.MilitaryStatus == vm.MilitaryStatus : true) && (vm.EducationLevel.HasValue ? s.EducationInfos.Any(e => e.EducationLevel == vm.EducationLevel) : true), s => s.Title, false, 10, vm.Page, "EducationInfos", "Location", "ResumeTags", "ResumeTags.Tag");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", vm.LocationId);
            ViewBag.Occupations = new SelectList(occupationRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", vm.OccupationId);
            return View(vm);
        }

    }
}