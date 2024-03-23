using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        TasteContext context = new TasteContext();
        public ActionResult Index()
        {
            ViewBag.sefsayı = context.Chefs.Count();
            ViewBag.menusayı = context.Products.Count();
            ViewBag.rezervesayı = context.Reservations.Count();
            return View();
        }
    }
}