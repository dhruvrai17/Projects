using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.Repository;
using CRM.UnityFramework;
using WebMatrix.WebData;

namespace CRM.Controllers
{
    public class ContactController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        //
        // GET: /Contact/
       // [Authorize]
        public ActionResult Index()
        {
            var id = WebSecurity.CurrentUserId;
            var contacts = unitOfWork.contactRepository.GetData();
                contacts = from n in contacts
                          where (n.UserId == id)
                          select n;
            return View(contacts);
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id = 0)
        {
            Contact contact = unitOfWork.contactRepository.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.contactRepository.Insert(contact);
                unitOfWork.Save();
                
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contact contact = unitOfWork.contactRepository.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.contactRepository.Update(contact);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contact contact = unitOfWork.contactRepository.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = unitOfWork.contactRepository.GetById(id);
            unitOfWork.contactRepository.Delete(contact);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}