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

        // GET: CREATE JobStatus
        public ActionResult Create()
        {
            return View();
        }

        // POST:CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobStatusCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateStatusService();
            if (service.CreateJobStatus(model))
            {
                TempData["SaveResult"] = "You job status was created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Job status could not be created.");
            return View(model);
        }

        // GET: DETAILS status
        public ActionResult Details (int id)
        {
            var service = CreateStatusService();
            var model = service.GetStatusById(id);
            return View(model);
        }

        // GET:EDIT status
        public ActionResult Edit (int id)
        {
            var service = CreateStatusService();
            var detail = service.GetStatusById(id);
            var model = new JobStatusEdit
            {
                StatusId = detail.StatusId,
                Status = detail.Status,
            };
            return View(model);
        }

        // POST:EDIT Status
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobStatusEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.StatusId != id)
            {
                ModelState.AddModelError("", "Status ID for Job does not match!");
                return View(model);
            }

            var service = CreateStatusService();
            if (service.UpdateStatus(model))
            {
                TempData["SaveResult"] = "Your job status was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your job status could not be updated!");
            return View(model);
        }

        // GET:Delete status
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStatusService();
            var model = svc.GetStatusById(id);
            return View(model);
        }

        // POST:DELETE Status
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteJob(int id)
        {
            var service = CreateStatusService();
            service.DeleteJobStatus(id);
            TempData["SaveResult"] = "Your job was deleted!";
            return RedirectToAction("Index");
        }

        public JobStatusService CreateStatusService()
        {
            var userId = User.Identity.GetUserId();
            var service = new JobStatusService(userId);
            return service;
        }



    }
}