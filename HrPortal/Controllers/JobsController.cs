using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;

namespace HrPortal.Controllers
{
    public class JobsController : Controller
    {
        private IRepository<Job> jobRepository;
        public JobsController (IRepository<Job> jobRepository)
        {
            this.jobRepository = jobRepository;
        }
        public IActionResult Index()
        {
            var jobs = jobRepository.GetAll();
            return View(jobs);

        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Detail()
        {
            return View();
        }
        public IActionResult Apply()
        {
            return View();
        }
    }
}