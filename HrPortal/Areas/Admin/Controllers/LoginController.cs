using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HrPortal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/[controller]")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}