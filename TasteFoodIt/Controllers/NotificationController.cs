using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class NotificationController : Controller
    {
        // GET: Notification
        TasteContext context = new TasteContext();
        public ActionResult NotificationList()
        {
            var values = context.Notifications.ToList();
            return View(values);
        }

        public ActionResult NotificationIsReadChangeToTrue(int id)
        {
            var value = context.Notifications.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }

        public ActionResult NotificationIsReadChangeToFalse(int id)
        {
            var value = context.Notifications.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
    }
}