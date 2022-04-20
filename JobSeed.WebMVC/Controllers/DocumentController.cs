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
    public class DocumentController : Controller
    {
        [Authorize]
        // GET: Document
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new DocumentService(userId);
            var model = service.GetDocs();
            return View(model);
        }

        // GET: Document
        public ActionResult Create()
        {
            return View();
        }

        // POST:CREATE Document/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DocumentCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateDocumentService();

            if (service.CreateDocument(model))
            {
                TempData["SaveResult"] = "Your document was added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your document could not be added.");
            return View(model);
        }

        // GET: DETAILS
        public ActionResult Details (int id)
        {
            var service = CreateDocumentService();
            var model = service.GetDocumentById(id);
            return View(model);
        }

        // GET: EDIT
        public ActionResult Edit (int id)
        {
            var service = CreateDocumentService();
            var detail = service.GetDocumentById(id);
            var model = new DocumentEdit
            {
                DocumentId = detail.DocumentId,
                DocumentType = detail.DocumentType
            };
            return View(model);
        }

        // POST:EDIT Document/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, DocumentEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.DocumentId != id)
            {
                ModelState.AddModelError("", "Your document ID does not match!");
                return View(model);
            }

            var service = CreateDocumentService();
            if (service.UpdateDocument(model))
            {
                TempData["SaveResult"] = "Your document was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your document could not be updated!");
            return View(model);
        }

        // GET: DELETE
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateDocumentService();
            var model = service.GetDocumentById(id);
            return View(model);
        }

        // POST:DELETE Document/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDocument(int id)
        {
            var service = CreateDocumentService();
            service.DeleteDocument(id);
            TempData["SaveResult"] = "Your document was deleted!";
            return RedirectToAction("Index");
        }
        public DocumentService CreateDocumentService()
        {
            var userId = User.Identity.GetUserId();
            var service = new DocumentService(userId);
            return service;
        }
    }
}