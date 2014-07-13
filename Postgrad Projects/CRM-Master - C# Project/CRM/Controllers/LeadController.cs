using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.UnityFramework;
using WebMatrix.WebData;

namespace CRM.Controllers
{
    public class LeadController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Lead/
        //[Authorize]
        public ActionResult Index()
        {
            var id = WebSecurity.CurrentUserId;
            var Leads = unitOfWork.leadRepository.GetData();
            Leads = from n in Leads
                         where (n.UserId == id)
                         select n;
            return View(Leads);
        }

        //
        // GET: /Lead/Details/5

        public ActionResult Details(int id = 0)
        {
            Lead lead = unitOfWork.leadRepository.GetById(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        //
        // GET: /Lead/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lead/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lead lead)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.leadRepository.Insert(lead);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(lead);
        }

        //
        // GET: /Lead/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Lead lead = unitOfWork.leadRepository.GetById(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        //
        // POST: /Lead/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Lead lead)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.leadRepository.Update(lead);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(lead);
        }

        //
        // GET: /Lead/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Lead lead = unitOfWork.leadRepository.GetById(id);
            if (lead == null)
            {
                return HttpNotFound();
            }
            return View(lead);
        }

        //
        // POST: /Lead/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lead lead = unitOfWork.leadRepository.GetById(id);
            unitOfWork.leadRepository.Delete(lead);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}