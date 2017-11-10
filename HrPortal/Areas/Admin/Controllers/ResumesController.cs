using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HrPortal.Areas.Admin.Controllers
{
    [Area("admin")]
    public class ResumesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}