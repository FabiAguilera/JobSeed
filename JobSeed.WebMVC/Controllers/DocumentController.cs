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
        // GET: Document
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new DocumentService(userId);
            var model = service.GetDocs();
            return View();
        }


    }
}