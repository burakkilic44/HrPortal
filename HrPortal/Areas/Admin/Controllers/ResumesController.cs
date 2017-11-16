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

namespace HrPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResumesController : Controller
    {
        private IRepository<Resume> resumeRepository;

        public ResumesController(IRepository<Resume> resumeRepository, IRepository<Location> locationRepository, IRepository<Language> languageRepository, IRepository<EducationInfo> educationInfoRepository, IRepository<Experience> experienceRepository, IRepository<Skill> skillRepository, IRepository<Certificate> certificateRepository, IRepository<Tag> tagRepository)
        {
            this.resumeRepository = resumeRepository;
        }

        // GET: Admin/Resumes
        public IActionResult Index()
        {
            var resumes = resumeRepository.GetAll("EducationInfos", "Location", "ResumeTags", "ResumeTags.Tag");
            return View(resumes);
        }
    }
}