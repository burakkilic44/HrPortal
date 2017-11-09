using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;

namespace HrPortal.Controllers
{
    public class ResumesController : Controller
    {

        private IRepository<Resume> resumeRepository;
        public ResumesController(IRepository<Resume> resumeRepository)
        {
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
            return View();
           
        }

        public IActionResult Edit()
        {
            return View();
        }
    }

}