using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLink.Models;
using DuLink.Entities;
using System.Configuration;

namespace DuLink.Controllers
{
    public class AccountController : Controller
    {
        AccountModel accountModel = new AccountModel();
        // GET: Account
        public ActionResult Index()
        {
            ViewBag.LISTA = accountModel.FindAll();
            return View();
        }


        /*****************************************/
        /*****************LOGIN*******************/
        /*****************************************/

        [HttpGet]
        public ActionResult Login()
        {      
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account currentUser)
        {
            
            if (loginMatches(currentUser))
            {
                Session["LoginErrorMessage"] = null;
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        private bool loginMatches(Account loggedUser)
        {
            List<Account> allUsers = accountModel.FindAll();
            foreach (Account user in allUsers)
            {
                if (user.UserName.Equals(loggedUser.UserName))
                {
                    if (user.Password.Equals(loggedUser.Password))
                    {
                        Session["ID"] = user.Id;
                        Session["Username"] = loggedUser.UserName;
                        return true;
                    }
                    else
                    {
                        Session["LoginErrorMessage"] = "Password for this user is incorrect!";
                        return false;
                    }
                }
            }
            Session["LoginErrorMessage"] = "No user was found with username: " + loggedUser.UserName;
            return false;
        }


        /*****************************************/
        /*****************LOG OUT*****************/
        /*****************************************/

        public ActionResult LogOut()
        {
            Session["ID"] = null;
            Session["Username"] = null;
            ViewBag.Jobs = null;
            ViewBag.Friends = null;
            return RedirectToAction("Index", "Home");
        }
        

        /*****************************************/
        /*****************REGISTRO****************/
        /*****************************************/

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Account nuevoUser)
        {           
            if (ModelState.IsValid)
            {
                if (isUserAllowed(nuevoUser))
                {
                    nuevoUser.FriendsList = new List<String>();
                    nuevoUser.JobsList = new List<String>();
                    accountModel.CreateAccount(nuevoUser);
                    Session["LoginErrorMessage"] = "Registration Successful, now log in!";
                    Session["CurrentErrorMessage"] = null;
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
            List<Account> allUsers = accountModel.FindAll();
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