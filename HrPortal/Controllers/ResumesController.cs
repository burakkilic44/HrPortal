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
        public ResumesController(IRepository<Resume> resumeRepository, IRepository<Location> locationRepository, IRepository<Language> languageRepository)
        {
            this.languageRepository = languageRepository;
            this.locationRepository = locationRepository;
            this.resumeRepository = resumeRepository;
        }
        public IActionResult Index()
        {
            var resumes = resumeRepository.GetAll();
            return View(resumes);
        }

        public IActionResult Details(string id)
        {
            var resume = resumeRepository.Get(id,"ResumeTags","ResumeTags.Tag","EducationInfos");
            return View(resume);
        }

        public IActionResult Create()
        {
            var resume = new Resume();
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            ViewBag.Languages = new SelectList(languageRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            return View();

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
            return View(resume);

        }

        public IActionResult Edit()
        {
            return View();
        }
    }

}