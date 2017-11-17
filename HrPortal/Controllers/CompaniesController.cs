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
    public class CompaniesController : Controller
    {
        private IRepository<Company> companyRepository;
        private IRepository<Location> locationRepository;
        private IRepository<Sector> sectorRepository;

        public CompaniesController(IRepository<Company> companyRepository,IRepository<Location> locationRepository, IRepository<Sector> sectorRepository)
        {
            this.companyRepository = companyRepository;
            this.locationRepository = locationRepository;
            this.sectorRepository = sectorRepository;
        }

        public async Task<IActionResult> Index(CompanySearchViewModel cvm)
        {
            cvm.SearchResults = await companyRepository.GetPaged(s => (!String.IsNullOrEmpty(cvm.Keywords) ? s.Title.Contains(cvm.Keywords) : true) && (!String.IsNullOrEmpty(cvm.LocationId) ? s.LocationId == cvm.LocationId: true) && (!String.IsNullOrEmpty(cvm.SectorId) ? s.SectorId == cvm.SectorId : true), o => o.Title, false, 10, cvm.Page, "Jobs", "Location");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", cvm.LocationId);
            ViewBag.Sector = new SelectList(sectorRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", cvm.SectorId);
            return View(cvm);
          
        }
        [Authorize(Roles = "Employer")]
        public IActionResult Details(string id)
        {
            var comp = companyRepository.Get(id, "Jobs", "Location");
            return View(comp);
        }
        [Authorize(Roles = "Employer")]
        public IActionResult Create()
        {
            var compa = new Company();
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            return View(compa);
        }

        [Authorize(Roles = "Employer")]
        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
               companyRepository.Insert(company);
                return RedirectToAction("SuccessfullyCreated");
            }
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            return View(company);
        }
        [Authorize(Roles = "Employer")]
        public IActionResult SuccessfullyCreated()
        {
            return View();
        }   
      
        public async Task<IActionResult> MyCompanies(CompanySearchViewModel cvm)
        {
            cvm.SearchResults = await companyRepository.GetPaged(s => (s.CreatedBy == User.Identity.Name) && (!String.IsNullOrEmpty(cvm.Keywords) ? s.Title.Contains(cvm.Keywords) : true) && (!String.IsNullOrEmpty(cvm.LocationId) ? s.LocationId == cvm.LocationId : true) && (!String.IsNullOrEmpty(cvm.SectorId) ? s.SectorId == cvm.SectorId : true), o => o.Title, false, 10, cvm.Page, "Jobs", "Location");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", cvm.LocationId);
            ViewBag.Sector = new SelectList(sectorRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", cvm.SectorId);
            return View(cvm);

        }


    }
}