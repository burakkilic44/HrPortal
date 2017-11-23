using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HrPortal.Controllers
{
    public class ControllerBase : Controller
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var auditRepository = (IRepository<Audit>)HttpContext.RequestServices.GetService(typeof(IRepository<Audit>));
            var audit = new Audit();
            // entityid'yi al
            // action adını al
            // varsa eski veriyi al
            // varsa yeni veriyi al
            audit.UserName = User.Identity.Name;
            auditRepository.Insert(audit);
        }

    }
}