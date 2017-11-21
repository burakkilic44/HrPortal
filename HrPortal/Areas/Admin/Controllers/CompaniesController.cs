using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;
using Microsoft.AspNetCore.Authorization;

namespace HrPortal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class CompaniesController : Controller
    {

        private IRepository<Company> companyRepository;

        public CompaniesController(IRepository<Company> companyRepository, IRepository<Location> locationRepository, IRepository<Sector>sectorRepository)
        {
            this.companyRepository = companyRepository;
        }



        public IActionResult Index()
        {


            var companies = companyRepository.GetAll("Sector", "Location");
            return View(companies);


        }
    }
}