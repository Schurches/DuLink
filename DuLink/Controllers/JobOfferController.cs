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
<<<<<<< HEAD
            String idUserLog=Session["ID"].ToString();
            Account userLog = accountModel.FindAccount(idUserLog);
            String carrerauserLog = userLog.Career;
            ViewBag.UsuarioOffer = userLog;
            ViewBag.ListaOfertas = jobOfferModel.FindAllByCareer(userLog.Career);
            ViewBag.ListaContactos = getUserFriendsList(userLog);
            ViewBag.ListaSugeridos = accountModel.FindSuggestedFriends(userLog);
=======
            if (Session["ID"] != null)
            {
                String idUserLog = Session["ID"].ToString();
                Account userLog = accountModel.FindAccount(idUserLog);
                String carrerauserLog = userLog.Career;
                ViewBag.ListaContactos = getUserFriendsList(userLog);
                ViewBag.ListaSugeridos = accountModel.FindSuggestedFriends(userLog);
            }else
            {
                //Johan, aqui es donde agregaras la busqueda de los 5 o 10 ultimos de la BD.
            }
>>>>>>> a9bab6eecf163c90033685b05094a944c08674d8
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
            ViewBag.UsuarioOffer = userLog;
            ViewBag.ListaOfertas = jobOfferModel.FindAllByCareer(userLog.Career);
            ViewBag.ListaContactos = getUserFriendsList(userLog);
            ViewBag.ListaSugeridos = accountModel.FindSuggestedFriends(userLog);
            if (ModelState.IsValid){
                jobOfferModel.CreateJobOffer(newOffer);
            }
            return View(newOffer);
        }

        [HttpGet]
        public ActionResult addFriend(String username)
        {
            accountModel.addFriend(accountModel.FindAccountByName(username).Id.ToString(), accountModel.FindAccount(Session["ID"].ToString()));
            return RedirectToAction("Home", "JobOffer");
        }

    }
}