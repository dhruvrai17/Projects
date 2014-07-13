using CRM.Filters;
using CRM.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    [InitializeSimpleMembership]
    public class HomeController : Controller
    {
        CrmDb _db = new CrmDb();
        //[Authorize]
        public ActionResult Index()
        {
            var model = _db.Profiles.ToList();
            return View(model);
        }
      
        public ActionResult About()
        {
            var model = new AboutModel();
            model.introduction = MyConsts.aboutIntroduction;
            model.email =MyConsts.aboutEmail;
            model.address = MyConsts.aboutAddress;

            return View(model);
        }
      
        public ActionResult Contact()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }  
            base.Dispose(disposing);
        }
    }
}
