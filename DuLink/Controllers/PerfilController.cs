using DuLink.Entities;
using DuLink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuLink.Controllers
{
    public class PerfilController : Controller
    {
        AccountModel accountModel = new AccountModel();
        JobsModel jobModel = new JobsModel();
        // GET: Perfil

        

        [HttpGet]
        public ActionResult Index(String userID)
        {
            if (Session["ID"] != null)
            {
                Account currentUser = accountModel.FindAccount(userID);
                getUserJobsList(currentUser);
                getUserFriendsList(currentUser);
                ViewBag.ProfileUsername = currentUser.UserName;
                ViewBag.ProfileName = currentUser.Name;
                ViewBag.ProfileLastname = currentUser.LastName;
                ViewBag.ProfileCareer = currentUser.Career;
                ViewBag.ProfileSemester = currentUser.Semester;
                ViewBag.ProfileEmail = currentUser.Mail;
                ViewBag.ProfileID = userID;
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }

        public ActionResult AddJob(Jobs newJob)
        {
            /*************************************************************************************************/
            /******OJO!!! EL MODEL STATE ACTUAL SOLO VALIDA (Company, Position, StartDate y EndDate)**********/
            /************SI SE LLEGA EN UN FUTURO A VALIDAR TODOS LOS CAMPOS, ESTO DEBE QUITARSE!*************/
            /*************************************************************************************************/
            if (ModelState.IsValid)
            {
                newJob.EmployeeId = Session["ID"].ToString();
                newJob.Name = newJob.Position;
                Jobs lastJob = jobModel.FindAll().Last();
                jobModel.CreateJobs(newJob);
                Account currentUser = accountModel.FindAccount(Session["ID"].ToString());
                accountModel.addJobToUser(jobModel.getLastAddedJob().Id.ToString(),currentUser,lastJob);
                getUserJobsList(currentUser);
            }
            return RedirectToAction("Index");
        }
        
        public void getUserJobsList(Account currentUser)
        {
            List<Jobs> allJobs = new List<Jobs>();
            foreach (var job in currentUser.JobsList)
            {
                allJobs.Add(jobModel.FindJobs(job));
            }
            ViewBag.Jobs = allJobs;
            ViewBag.JobCount = allJobs.Count;
        }

        public void getUserFriendsList(Account currentUser)
        {
            List<Account> allFriends = new List<Account>();
            foreach (var friend in currentUser.FriendsList)
            {
                allFriends.Add(accountModel.FindAccount(friend));
            }
            ViewBag.FriendsCount = allFriends.Count;
            ViewBag.FriendsList = allFriends;
        }

    }
}