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
    public class CampaignsController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        //
        // GET: /Campaigns/

        public ActionResult Index()
        {
            var id = WebSecurity.CurrentUserId;
            var campaigns = unitOfWork.campaignRepository.GetData();
            campaigns = from n in campaigns
                         where (n.UserId == id)
                         select n;
            return View(campaigns);
        }

        //
        // GET: /Campaigns/Details/5

        public ActionResult Details(int id = 0)
        {
            Campaign campaign = unitOfWork.campaignRepository.GetById(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        //
        // GET: /Campaigns/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Campaigns/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.campaignRepository.Insert(campaign);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(campaign);
        }

        //
        // GET: /Campaigns/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Campaign campaign = unitOfWork.campaignRepository.GetById(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        //
        // POST: /Campaigns/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.campaignRepository.Update(campaign);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(campaign);
        }

        //
        // GET: /Campaigns/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Campaign campaign = unitOfWork.campaignRepository.GetById(id);
            if (campaign == null)
            {
                return HttpNotFound();
            }
            return View(campaign);
        }

        //
        // POST: /Campaigns/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campaign campaign = unitOfWork.campaignRepository.GetById(id);
            unitOfWork.campaignRepository.Delete(campaign);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}