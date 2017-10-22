﻿using System;
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
                Session["CurrentErrorMessage"] = null;
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
                        Session["Name"] = user.Name;
                        Session["ID"] = user.Id;
                        Session["LastName"] = user.LastName;
                        Session["Email"] = user.Mail;
                        Session["Career"] = user.Career;
                        Session["Semester"] = user.Semester;
                        Session["Username"] = loggedUser.UserName;
                        ViewBag.Jobs = user.JobsList;
                        ViewBag.Friends = user.FriendsList;
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
        /*****************LOG OUT*****************/
        /*****************************************/

        public ActionResult LogOut()
        {
            Session["Name"] = null;
            Session["ID"] = null;
            Session["LastName"] = null;
            Session["Email"] = null;
            Session["Career"] = null;
            Session["Semester"] = null;
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
                    accountModel.CreateAccount(nuevoUser);
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