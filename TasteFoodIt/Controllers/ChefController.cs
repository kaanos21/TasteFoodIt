using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class ChefController : Controller
    {
        // GET: Chef
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            var value = context.Chefs.ToList();
            return View(value);
        }
        public ActionResult ChefList()
        {
            return View();
        }
        public ActionResult ChefListtt()
        {
            var value = context.Chefs.ToList();
            return View(value);
        }
    }
}