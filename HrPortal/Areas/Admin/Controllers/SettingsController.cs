using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HrPortal.Services;
using HrPortal.Models;

namespace HrPortal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        private IRepository<Setting> settingRepository;
        public SettingsController(IRepository<Setting> settingRepository)
        {
            this.settingRepository = settingRepository;
        }
        public IActionResult Edit()
        {
            var setting = settingRepository.GetAll().FirstOrDefault();
            return View(setting);
        }
    }
}