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
    public class ActivitiesController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Activities/

        public ActionResult Index()
        {
            var id = WebSecurity.CurrentUserId;
            var activities = unitOfWork.activityRepository.Get(includeProperties: "Lead,Contact");
            activities = from n in activities
                       where (n.UserId == id)
                       select n;
            return View(activities.ToList());
        }

        //
        // GET: /Activities/Details/5

        public ActionResult Details(int id = 0)
        {
            Activity activity = unitOfWork.activityRepository.GetById(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // GET: /Activities/Create

        public ActionResult Create()
        {
            PopulateLeadsDropDownList();
            PopulateContactsDropDownList();
            return View();
        }

        //
        // POST: /Activities/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.activityRepository.Insert(activity);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            PopulateLeadsDropDownList();
            PopulateContactsDropDownList();
            
            return View(activity);
        }

        private void PopulateLeadsDropDownList(object potential = null)
        {
            var userId = WebSecurity.CurrentUserId;
            var leadsQuery = unitOfWork.leadRepository.Get(orderBy: q => q.OrderBy(d => d.LeadId));
            leadsQuery = from n in leadsQuery
                         where (n.UserId == userId)
                         select n;
            ViewBag.LeadId = new SelectList(leadsQuery, "LeadId", "LeadName", potential);
        }

        private void PopulateContactsDropDownList(object potential = null)
        {
            var userId = WebSecurity.CurrentUserId;
            var contactQuery = unitOfWork.campaignRepository.Get(orderBy: q => q.OrderBy(d => d.CampaignId));
            contactQuery = from n in contactQuery
                            where (n.UserId == userId)
                            select n;
            ViewBag.ContactId = new SelectList(contactQuery, "ContactId", "ContactName", potential);
        }

        //
        // GET: /Activities/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Activity activity = unitOfWork.activityRepository.GetById(id);
            if (activity == null)
            {
                return HttpNotFound();
            }

            PopulateLeadsDropDownList();
            PopulateContactsDropDownList();
            
            return View(activity);
        }

        //
        // POST: /Activities/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.activityRepository.Update(activity);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            PopulateLeadsDropDownList();
            PopulateContactsDropDownList();
            return View(activity);
        }

        //
        // GET: /Activities/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Activity activity = unitOfWork.activityRepository.GetById(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        //
        // POST: /Activities/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = unitOfWork.activityRepository.GetById(id);
            unitOfWork.activityRepository.Delete(activity);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}