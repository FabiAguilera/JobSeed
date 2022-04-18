using JobSeed.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSeed.WebMVC.Controllers
{
    public class JobStatusController : Controller
    {
        // GET: JobStatus entity
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new JobStatusService(userId);
            var model = service.GetStatus();
            return View(model);
        }


    }
}