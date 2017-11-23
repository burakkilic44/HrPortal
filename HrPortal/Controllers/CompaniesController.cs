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
    public class CompaniesController : ControllerBase
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
            //s => (vm.SortBy == 1 || vm.SortBy == 2 ? s.FullName : (vm.SortBy == 3 || vm.SortBy == 4 ? s.Occupation.Name : (vm.SortBy == 5 || vm.SortBy == 6 ? s.Location.Name : s.UpdateDate.ToString()))), (vm.SortBy == 1 || vm.SortBy == 3 || vm.SortBy == 5 ? false : (vm.SortBy == 2 || vm.SortBy == 4 || vm.SortBy == 6)
            cvm.SearchResults = await companyRepository.GetPaged(s => 
            (!String.IsNullOrEmpty(cvm.Keywords) ? s.Name.Contains(cvm.Keywords) : true) && 
            (!String.IsNullOrEmpty(cvm.LocationId) ? s.LocationId == cvm.LocationId: true) && 
            (!String.IsNullOrEmpty(cvm.SectorId) ? s.SectorId == cvm.SectorId : true),
            s => (cvm.SortBy == 1 || cvm.SortBy == 2 ? s.Name : (cvm.SortBy == 3 || cvm.SortBy == 4 ? s.Sector.Name : (cvm.SortBy == 5 || cvm.SortBy == 6 ? s.Location.Name : s.UpdateDate.ToString()))),
            (cvm.SortBy == 1 || cvm.SortBy == 3 || cvm.SortBy == 5 ? false : (cvm.SortBy == 2 || cvm.SortBy == 4 || cvm.SortBy == 6)),
                5, cvm.Page, "Jobs", "Location");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name", cvm.LocationId);
            ViewBag.Sector = new SelectList(sectorRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name", cvm.SectorId);
            return View(cvm);
          
        }
        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Details(string id)
        {
            var comp = companyRepository.Get(id, "Jobs", "Location", "Jobs.JobLocations", "Jobs.JobLocations.Location");
            return View(comp);
        }
        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Create()
        {
            var compa = new Company();
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            ViewBag.Sectors = new SelectList(sectorRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name");
            return View(compa);
        }

        [Authorize(Roles = "Employer,Admin")]
        [HttpPost]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
               companyRepository.Insert(company);
                return RedirectToAction("SuccessfullyCreated");
            }
            ViewBag.Companies = new SelectList(companyRepository.GetAll().OrderBy(c => c.Name).ToList(), "Id", "Name");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(l => l.Name).ToList(), "Id", "Name");
            ViewBag.Sectors = new SelectList(sectorRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name");
            return View(company);
        }
        [Authorize(Roles = "Employer,Admin")]
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
        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Edit(string id)
        {

            var company = companyRepository.GetMany(c => c.Id == id && (!User.IsInRole("Admin") ? c.CreatedBy == User.Identity.Name : true)).FirstOrDefault();
            if (company == null)
            {
                return NotFound();
            }
            ViewBag.Sectors = new SelectList(sectorRepository.GetAll().OrderBy(p => p.Name).ToList(), "Id", "Name");
            ViewBag.Locations = new SelectList(locationRepository.GetAll().OrderBy(o => o.Name).ToList(), "Id", "Name");
            return View(company);
        }
        [Authorize(Roles = "Employer,Admin")]
        [HttpPost]
        public IActionResult Edit(Company company)
        {
            if (!User.IsInRole("Admin") && company.CreatedBy != User.Identity.Name)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                companyRepository.Update(company);
                return RedirectToAction("MyCompanies");
            }
            
            ViewBag.Locations = locationRepository.GetAll().OrderBy(l => l.Name).ToList();
            return View(company);

        }
        [Authorize(Roles = "Employer,Admin")]
        public IActionResult Delete(string id)
        {
            var company = companyRepository.GetMany(c => c.Id == id && (!User.IsInRole("Admin") ? c.CreatedBy == User.Identity.Name : true)).FirstOrDefault();

            if (company == null)
            {
                return NotFound();
            }
            companyRepository.Delete(company);
            return RedirectToAction("MyCompanies");
        }


    }
}