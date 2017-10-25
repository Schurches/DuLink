using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLink.Models;
namespace DuLink.Controllers
{
    public class SearchController : Controller
    {
       
        AccountModel accountModel = new AccountModel();
        JobOfferModel jobOfferModel = new JobOfferModel();
        // GET: Search
        public ActionResult Search()
        {
            ViewBag.UsersList = null;
            ViewBag.OfferList = null;
            return View();
        }

        [HttpPost]
        public ActionResult Search(String keyWords,String UserSearch, String OfferSearch)
        {
            ViewBag.TitleSearchUser = "Search User by " + UserSearch;
            ViewBag.TitleSearchOffer = "Search Offer by " + OfferSearch;
            if (UserSearch.Equals("Name"))
            {
                ViewBag.UsersList = accountModel.FindAllByName(keyWords);
            }
            else if (UserSearch.Equals("LastName"))
            {
                ViewBag.UsersList = accountModel.FindAllByLastName(keyWords);
            }
            else if (UserSearch.Equals("Career"))
            {
                ViewBag.UsersList = accountModel.FindAllByCareer(keyWords);
            }
            else if (UserSearch.Equals("Semester"))
            {
                ViewBag.UsersList = accountModel.FindAllBySemester(keyWords);
               
            }

            if (OfferSearch.Equals("CompanyName"))
            {
                ViewBag.OfferList = jobOfferModel.FindAllByCompanyName(keyWords);
            }
            else if (OfferSearch.Equals("Description"))
            {
                ViewBag.OfferList = jobOfferModel.FindAllByDescription(keyWords);
            }
            return View();
        }

    }
}