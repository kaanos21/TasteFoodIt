using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminOpenHoursController : Controller
    {
        // GET: AdminOpenHours
        TasteContext context = new TasteContext();
        public ActionResult OpenHoursList()
        {
            var value = context.openDayHours.ToList();
            return View(value);
        }

        public ActionResult DeleteDay(int id)
        {
            var value = context.openDayHours.Find(id);
            context.openDayHours.Remove(value);
            context.SaveChanges();
            return RedirectToAction("OpenHoursList");
        }
        [HttpGet]
        public ActionResult UpdateDay(int id)
        {
            var value = context.openDayHours.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateDay(OpenDayHour t)
        {
            var value = context.openDayHours.Find(t.OpenDayHourId);
            value.DayName = t.DayName;
            value.OpenHourRangw = t.OpenHourRangw;
            context.SaveChanges();
            return RedirectToAction("OpenHoursList");
        }
        [HttpGet]
        public ActionResult CreateDay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDay(OpenDayHour t)
        {
            context.openDayHours.Add(t);
            context.SaveChanges();
            return RedirectToAction("OpenHoursList");
        }
    }
}