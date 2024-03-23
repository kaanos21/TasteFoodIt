using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSidebar()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            ViewBag.notificationIsReadyByFalseCount = context.Notifications.Where(x => x.IsRead == false).Count();
            var value = context.Notifications.Where(x => x.IsRead == false).ToList();
            return PartialView(value);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public ActionResult NotificationStatusChangeToTrue(int id)
        {
            var value = context.Notifications.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category");
        }
        public PartialViewResult Message(Mail t)
        {
            var value = context.Mails.ToList();
            ViewBag.cc = context.Mails.Count();
            return PartialView(value);
        }
    }
}