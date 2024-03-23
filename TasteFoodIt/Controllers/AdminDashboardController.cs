using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class AdminDashboardController : Controller
    {
        // GET: AdminDashboard
        TasteContext context = new TasteContext();
        public ActionResult Dashboard()
        {
            return View();
        }

        public PartialViewResult Reservations()
        {
            var value = context.Reservations.ToList();
            return PartialView(value);
        }

        public PartialViewResult Notifications()
        {
            var value = context.Notifications.ToList();
            return PartialView(value);
        }
    }
}