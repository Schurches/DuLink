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
                // = findUser();
                newJob.EmployeeId = Session["ID"].ToString();
                newJob.Name = newJob.Position;
                jobModel.CreateJobs(newJob);
            }
            return RedirectToAction("Index");
        }

        public Account findUser()
        {
            return accountModel.FindAccount(Session["ID"].ToString());
        }
        
    }
}