using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DuLink.Models;

namespace DuLink.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            AccountModel account = new AccountModel();
            ViewBag.LISTA = account.FindAll();
            return View();
        }
    }
}