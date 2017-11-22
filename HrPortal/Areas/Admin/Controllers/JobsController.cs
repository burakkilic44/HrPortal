using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HrPortal.Data;
using HrPortal.Models;
using HrPortal.Services;
using Microsoft.AspNetCore.Authorization;

namespace HrPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class JobsController : Controller
    {
        private IRepository<Job> jobRepository;
        private IRepository<Location> locationRepository;

        public JobsController(IRepository<Job> jobRepository, IRepository<Location> locationRepository)
        {
            this.jobRepository = jobRepository;
            this.locationRepository = locationRepository;
        }

        // GET: Admin/Resumes
        public IActionResult Index()
        {
            var jobs = jobRepository.GetAll("JobLocations", "JobLocations.Location");
            return View(jobs);
        }


    }
}