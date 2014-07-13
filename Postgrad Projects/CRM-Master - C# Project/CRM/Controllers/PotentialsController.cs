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
    public class PotentialsController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Potentials/

        public ActionResult Index()
        {
            var id = WebSecurity.CurrentUserId;
            var potentials = unitOfWork.potentialRepository.Get(includeProperties: "Lead,Campaign");
            potentials = from n in potentials
                         where (n.UserId == id)
                         select n;
            return View(potentials);
        }

        //
        // GET: /Potentials/Details/5

        public ActionResult Details(int id = 0)
        {
            Potential potential = unitOfWork.potentialRepository.GetById(id);
            if (potential == null)
            {
                return HttpNotFound();
            }
            return View(potential);
        }

        //
        // GET: /Potentials/Create

        public ActionResult Create()
        {
            PopulateCampaignsDropDownList();
            PopulateLeadsDropDownList();

            return View();
        }

        //
        // POST: /Potentials/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Potential potential)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.potentialRepository.Insert(potential);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            PopulateLeadsDropDownList();
            PopulateCampaignsDropDownList();
            return View(potential);
        }

        private void PopulateLeadsDropDownList(object potential = null)
        {
            var userId = WebSecurity.CurrentUserId;
            var leadsQuery = unitOfWork.leadRepository.Get(orderBy: q => q.OrderBy(d => d.LeadId));
            leadsQuery = from n in leadsQuery
                         where (n.UserId == userId)
                               select n;
            ViewBag.LeadId = new SelectList(leadsQuery, "LeadId", "LeadName",potential);
        }

        private void PopulateCampaignsDropDownList(object potential = null)
        {
            var userId = WebSecurity.CurrentUserId;
            var campaignQuery = unitOfWork.campaignRepository.Get(orderBy: q => q.OrderBy(d => d.CampaignId));
            campaignQuery = from n in campaignQuery
                               where (n.UserId == userId)
                               select n;
            ViewBag.CampaignId = new SelectList(campaignQuery, "CampaignId", "CampaignName",potential);
        }

        //
        // GET: /Potentials/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Potential potential = unitOfWork.potentialRepository.GetById(id);
            if (potential == null)
            {
                return HttpNotFound();
            }
            PopulateCampaignsDropDownList();
            PopulateLeadsDropDownList();
            return View(potential);
        }

        //
        // POST: /Potentials/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Potential potential)
        {
            PopulateCampaignsDropDownList();
            PopulateLeadsDropDownList();

            if (ModelState.IsValid)
            {
                unitOfWork.potentialRepository.Update(potential);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(potential);
        }

        //
        // GET: /Potentials/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Potential potential = unitOfWork.potentialRepository.GetById(id);
            if (potential == null)
            {
                return HttpNotFound();
            }
            return View(potential);
        }

        //
        // POST: /Potentials/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Potential potential = unitOfWork.potentialRepository.GetById(id);
            unitOfWork.potentialRepository.Delete(potential);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}