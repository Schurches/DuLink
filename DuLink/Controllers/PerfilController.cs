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

        public ActionResult Index(Jobs job)
        {
            return View(job);
        }

        [HttpGet]
        public ActionResult Index(String userID)
        {
            if (Session["ID"] != null)
            {
                if(userID == null)
                {
                    userID = Session["ID"].ToString();
                }else
                {
                    if (!userID.Equals(Session["ID"]))
                    {
                        Account currentUser = accountModel.FindAccount(Session["ID"].ToString());
                        if (currentUser.FriendsList.Contains(userID) || Session["ID"].ToString().Equals(userID))
                        {
                            ViewBag.isFriend = true;
                        }
                        else
                        {
                            ViewBag.isFriend = false;
                        }
                    }
                }
                Account currentProfile = accountModel.FindAccount(userID);
                getUserJobsList(currentProfile);
                getUserFriendsList(currentProfile);
                ViewBag.Profile = currentProfile;
                ViewBag.ProfileID = currentProfile.Id.ToString();
            }
            else
            {
                return RedirectToAction("Login","Account");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                accountModel.addJobToUser(jobModel.getLastAddedJob().Id.ToString(), currentUser, lastJob);
                getUserJobsList(currentUser);
                return RedirectToAction("Index", new { userID = Session["ID"].ToString() });
            }else
            {
                return RedirectToAction("Index", newJob);
            }
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

        [HttpGet]
        public ActionResult addFriend(String username)
        {
            accountModel.addFriend(accountModel.FindAccountByName(username).Id.ToString(), accountModel.FindAccount(Session["ID"].ToString()));
            return RedirectToAction("Index", "Perfil");
        }

    }
}