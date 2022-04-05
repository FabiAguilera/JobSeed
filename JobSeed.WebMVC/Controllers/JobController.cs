using JobSeed.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSeed.WebMVC.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new JobService(userId);
            var model = service.GetJobs();

            return View(model);
        }
    }

    public ActionResult Create()
    {
        return View();
    }

    public JobService CreateJobService()
    {
        return new JobService(User.Identity.GetUserId);
    }
}