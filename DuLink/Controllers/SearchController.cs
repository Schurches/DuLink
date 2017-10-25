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
            return View();
        }

        [HttpPost]
        public ActionResult Search(String keyWords){
            Session["BusquedaKeyWords"] = keyWords;
            Session["TitleSearchUser"] = "Search User by Name";
            Session["UsersList"] = accountModel.FindAllByName(keyWords);
            Session["OfferList"] = null;
            return View();
        }

        public ActionResult SearchType(String UserSearch, String OfferSearch)
        {
            Session["TitleSearchUser"] = "Search User by " + UserSearch;
            Session["TitleSearchOffer"]  = "Search Offer by " + OfferSearch;
            if (UserSearch.Equals("Name"))
            {
                Session["UsersList"] = accountModel.FindAllByName(Session["BusquedaKeyWords"].ToString());
            }
            else if (UserSearch.Equals("LastName"))
            {
                Session["UsersList"] = accountModel.FindAllByLastName(Session["BusquedaKeyWords"].ToString());
            }
            else if (UserSearch.Equals("Career"))
            {
                Session["UsersList"] = accountModel.FindAllByCareer(Session["BusquedaKeyWords"].ToString());
            }
            else if (UserSearch.Equals("Semester"))
            {
                Session["UsersList"] = accountModel.FindAllBySemester(Session["BusquedaKeyWords"].ToString());
            }
            else {
                Session["UsersList"] = null;
            }

            if (OfferSearch.Equals("CompanyName"))
            {
                Session["OfferList"] = jobOfferModel.FindAllByCompanyName(Session["BusquedaKeyWords"].ToString());
            }
            else if (OfferSearch.Equals("Description"))
            {
                Session["OfferList"] = jobOfferModel.FindAllByDescription(Session["BusquedaKeyWords"].ToString());
            }
            else {
                Session["OfferList"] = null;
            }
            return RedirectToAction("Search", "Search");
        }
    }
}