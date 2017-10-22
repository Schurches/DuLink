using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLink.Entities;
using DuLink.Models;

namespace DuLink.Controllers
{
    public class JobOfferController : Controller
    {
        JobOfferModel jobOfferModel = new JobOfferModel();
        // GET: JobOffer
        public ActionResult PostOffer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostOffer(JobOffer newOffer)
        {
            if (ModelState.IsValid){
                jobOfferModel.CreateJobOffer(newOffer);
            }
            return View(newOffer);
        }
    }
}