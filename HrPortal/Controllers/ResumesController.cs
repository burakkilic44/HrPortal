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
    public class ResumesController : Controller
    {
        
        private IRepository<Resume> resumeRepository;
        private IRepository<Location> locationRepository;
        private IRepository<Language> languageRepository;
        private IRepository<EducationInfo> educationInfoRepository;
        private IRepository<Experience> experienceRepository;
        private IRepository<Skill> skillRepository;
        private IRepository<Certificate> certificateRepository;
        
      public ResumesController(IRepository<Resume> resumeRepository, IRepository<Location> locationRepository, IRepository<Language> languageRepository, IRepository<EducationInfo> educationInfoRepository, IRepository<Experience> experienceRepository, IRepository<Skill> skillRepository, IRepository<Certificate> certificateRepository)
        {
            this.languageRepository = languageRepository;
            this.locationRepository = locationRepository;
            this.resumeRepository = resumeRepository;
            this.educationInfoRepository = educationInfoRepository;
            this.experienceRepository = experienceRepository;
            this.skillRepository = skillRepository;
            this.certificateRepository = certificateRepository;
            
        }
        public IActionResult Index()
        {
            var resumes = resumeRepository.GetAll("EducationInfos","Location", "ResumeTags", "ResumeTags.Tag");
            return View(resumes);
        }

        public IActionResult Details(string id)
        {
            var resume = resumeRepository.Get(id,"ResumeTags","ResumeTags.Tag","EducationInfos","Experiences");
            return View(resume);
        }

        public IActionResult Create()
        {
            var resume = new Resume();
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            return View(resume);
        }

        [HttpPost]
        public IActionResult Create(Resume resume)
        {
            if (ModelState.IsValid)
            {
                resumeRepository.Insert(resume);
            }
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.IsModelStateValid = ModelState.IsValid;
            return View(resume);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult EducationInfos()
        {
            var EducationInfo = new EducationInfo();
            return View(EducationInfo);
        }

        [HttpPost]
        public JsonResult AddEducationInfo(EducationInfo educationinfo)
        {
            if (ModelState.IsValid)
            {
                educationInfoRepository.Insert(educationinfo);
            }
            return Json("Success");
        }

        public IActionResult Experience()
        {
            
            var Experience = new Experience();
            return View(Experience);
        }

        [HttpPost]
        public JsonResult AddExperience(Experience experience)
        {
            if (ModelState.IsValid)
            {
                experienceRepository.Insert(experience);
            }
            return Json("Success");
        }

        public IActionResult Skill()
        {
            var Skill = new Skill();
            return View(Skill);
        }

        [HttpPost]
        public JsonResult AddSkill(Skill skill)
        {
            if (ModelState.IsValid)
            {
               skillRepository.Insert(skill);
            }
            return Json("Success");
        }

        public IActionResult Certificate()
        {
            var Certificate = new Certificate();
            return View(Certificate);
        }

        [HttpPost]
        public JsonResult AddCertificate(Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                certificateRepository.Insert(certificate);
            }
            return Json("Success");
        }

        public IActionResult LanguageInfos()
        {
            var languageInfo = new LanguageInfo();
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            return View(languageInfo);
        }

        [HttpPost]
        public JsonResult AddLanguageInfo(LanguageInfo languageInfo)
        {
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            return Json("Success");      
        } 
    }
}