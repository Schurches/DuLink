using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLink.Models;
using MongoDB.Driver;
using DuLink.Entities;
using System.Configuration;

namespace DuLink.Controllers
{
    public class AccountController : Controller
    {
        private MongoClient mongoClient;
        private IMongoCollection<Account> accountCollection;
        // GET: Account
        public ActionResult Index()
        {
            AccountModel account = new AccountModel();
            ViewBag.LISTA = account.FindAll();
            return View();
        }

        public void iniAccountList()
        {
            if (accountCollection == null)
            {
                mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
                var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
                accountCollection = db.GetCollection<Account>("Employee");
            }
        }


        /*****************************************/
        /*****************LOGIN****************/
        /*****************************************/

        [HttpGet]
        public ActionResult Login()
        {
            iniAccountList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account currentUser)
        {
            iniAccountList();
            if (loginMatches(currentUser))
            {
                Session["CurrentErrorMessage"] = null;
                return RedirectToAction("Index");
            }
            return View();
        }

        private bool loginMatches(Account loggedUser)
        {
            List<Account> allUsers = accountCollection.AsQueryable<Account>().ToList();
            foreach (Account user in allUsers)
            {
                if (user.UserName.Equals(loggedUser.UserName))
                {
                    if (user.Password.Equals(loggedUser.Password))
                    {
                        Session["Username"] = loggedUser.UserName;
                        return true;
                    }
                    else
                    {
                        Session["CurrentErrorMessage"] = "Password for this user is incorrect!";
                        return false;
                    }
                }
            }
            Session["CurrentErrorMessage"] = "No user was found with username: " + loggedUser.UserName;
            return false;
        }

        /*****************************************/
        /*****************REGISTRO****************/
        /*****************************************/

        public ActionResult Registro()
        {
            iniAccountList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Account nuevoUser)
        {
            iniAccountList();
            if (ModelState.IsValid)
            {
                if (isUserAllowed(nuevoUser))
                {
                    accountCollection.InsertOne(nuevoUser);
                    Session["CurrentErrorMessage"] = "Registration Successful, now log in!";
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                Session["CurrentErrorMessage"] = null;
            }
            return View(nuevoUser);
        }

        
        private bool isUserAllowed(Account usuario) {
            List<Account> allUsers = accountCollection.AsQueryable<Account>().ToList();
            foreach (Account user in allUsers)
            {
                if (user.UserName.Equals(usuario.UserName))
                {
                    Session["CurrentErrorMessage"] = "This username is already taken!";
                    return false;
                }
                if (user.Mail.Equals(usuario.Mail))
                {
                    Session["CurrentErrorMessage"] = "This mail is already taken!";
                    return false;
                }
            }
            return true;
        }

    }
}