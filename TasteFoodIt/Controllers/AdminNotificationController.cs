using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminNotificationController : Controller
    {
        // GET: AdminNotification
        TasteContext context = new TasteContext();
        public ActionResult NotificationList()
        {
            var value=context.Notifications.ToList();
            return View(value);
        }
        public ActionResult DeleteNotification(int id)
        {
            var value = context.Notifications.Find(id);
            context.Notifications.Remove(value);
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        [HttpGet]
        public ActionResult UpdateNotification(int id)
        {
            var value = context.Notifications.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateNotification(Notification t)
        {
            var value = context.Notifications.Find(t.NotificationId);
            value.Description = t.Description;
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }
        [HttpGet]
        public ActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNotification(Notification t)
        {
            t.Date = DateTime.Now;
            context.Notifications.Add(t);
            context.SaveChanges();
            return RedirectToAction("NotificationList");
        }

    }
}