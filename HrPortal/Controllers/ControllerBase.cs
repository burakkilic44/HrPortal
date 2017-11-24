using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HrPortal.Services;
using HrPortal.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json.Linq;

namespace HrPortal.Controllers
{
    public class ControllerBase : Controller
    {
        private ActionExecutedContext context;

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var auditRepository = (IRepository<Audit>)HttpContext.RequestServices.GetService(typeof(IRepository<Audit>));
            var audit = new Audit();

           
            audit.Ip = context.HttpContext.Request.Host.ToString();
            audit.Action = context.RouteData.Values["action"].ToString();
            audit.Controller = context.RouteData.Values["controller"].ToString();
            audit.EntityId = context.ActionDescriptor.Id;
            audit.UserAgent = context.HttpContext.Request.Headers["user-agent"].ToString();
               
            
            // varsa eski veriyi al
            // varsa yeni veriyi al
            audit.UserName = User.Identity.Name;
            auditRepository.Insert(audit);
        }

    }
}