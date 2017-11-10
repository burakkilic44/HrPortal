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
        public ResumesController(IRepository<Resume> resumeRepository, IRepository<Location> locationRepository)
        {
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

            return View();
        }

        public IActionResult Create()
        {
            var resume = new Resume();
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            return View();

        }

        [HttpPost]
        public IActionResult Create(Resume resume)
        {
            if (ModelState.IsValid)
            {
                resumeRepository.Insert(resume);
                return RedirectToAction("Index");
            }
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            return View(resume);

        }

        public IActionResult Edit()
        {
            return View();
        }
    }

}