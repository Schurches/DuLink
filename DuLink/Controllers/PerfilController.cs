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
        public ActionResult Index()
        {
            Account currentUser = accountModel.FindAccount(Session["ID"].ToString());
            getUserJobsList(currentUser);
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

    }
}