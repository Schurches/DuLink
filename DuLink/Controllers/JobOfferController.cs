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
        AccountModel accountModel = new AccountModel();
        JobOfferModel jobOfferModel = new JobOfferModel();
        // GET: JobOffer
        public ActionResult Home()
        {
            String idUserLog=Session["ID"].ToString();
            Account userLog = accountModel.FindAccount(idUserLog);
            String carrerauserLog = userLog.Career;
            ViewBag.ListaContactos = getUserFriendsList(userLog);
            ViewBag.ListaSugeridos = accountModel.FindSuggestedFriends(userLog);
            return View();
        }

        public List<Account>  getUserFriendsList(Account currentUser)
        {
            List<Account> allFriends = new List<Account>();
            foreach (var friend in currentUser.FriendsList)
            {
                allFriends.Add(accountModel.FindAccount(friend));
            }
            return allFriends;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Home(JobOffer newOffer)
        {
            String idUserLog = Session["ID"].ToString();
            Account userLog = accountModel.FindAccount(idUserLog);
            String carrerauserLog = userLog.Career;
            ViewBag.ListaContactos = getUserFriendsList(userLog);
            ViewBag.ListaSugeridos = accountModel.FindSuggestedFriends(userLog);
            if (ModelState.IsValid){
                jobOfferModel.CreateJobOffer(newOffer);
            }
            return View(newOffer);
        }
    }
}