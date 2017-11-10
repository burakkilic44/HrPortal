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
    public class CompaniesController : Controller
    {
        private IRepository<Company> companyRepository;
        private IRepository<Location> locationRepository;

        public CompaniesController(IRepository<Company> companyRepository,IRepository<Location> locationRepository)
        {
            this.companyRepository = companyRepository;
            this.locationRepository = locationRepository;
        }
        public IActionResult Index()
        {
            var companys = companyRepository.GetAll("Jobs","Location");
            return View(companys);
        }

        public IActionResult Details(string id)
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}