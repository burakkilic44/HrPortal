using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HrPortal.Controllers
{
    public class JobApplicationController : Controller
    {
        public IActionResult MyApplications()
        {   

            return View();
        }


        public IActionResult Application()
        {
            return View();
        }

    }
}