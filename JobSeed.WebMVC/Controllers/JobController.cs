using JobSeed.Models;
using JobSeed.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSeed.WebMVC.Controllers
{
    public class JobController : Controller
    {
        [Authorize]
        // GET: Job
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new JobService(userId);
            var model = service.GetJobs();

            return View(model);
        }

        // GET: CREATE Job
        public ActionResult Create()
        {
            return View();
        }

        // POST:CREATE Job/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateJobService();

            if (service.CreateJob(model))
            {
                TempData["SaveResult"] = "Your job was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Job could not be created.");
            return View(model);
        }

        // GET: DETAILS
        public ActionResult Details (int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);
            return View(model);
        }

        // GET: EDIT
        public ActionResult Edit (int id)
        {
            var service = CreateJobService();
            var detail = service.GetJobById(id);
            var model = new JobEdit
            {
                JobId = detail.JobId,
                Position = detail.Position,
                Company = detail.Company,
                URL = detail.URL,
                Salary = detail.Salary,
                Location = detail.Location
            };
            return View(model);
        }

        // POST: EDIT Job/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if(model.JobId != id)
            {
                ModelState.AddModelError("", "Job ID mismatch");
                return View(model);
            }

            var service = CreateJobService();
            if (service.UpdateJob(model))
            {
                TempData["SaveResult"] = "Your job was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your job could not updated!");
            return View(model);
        }

        // GET: DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateJobService();
            var model = svc.GetJobById(id);
            return View(model);
        }

        // POST:DELETE Job/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateJobService();
            service.DeleteJob(id);
            TempData["SaveResult"] = "Your job was deleted!";
            return RedirectToAction("Index");
        }

        public JobService CreateJobService()
        {
            var userId = User.Identity.GetUserId();
            var service = new JobService(userId);
            return service;
        }
    }
}