using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class SlideController : Controller
    {
        // GET: Slide
        TasteContext context = new TasteContext();
        [HttpGet]
        public ActionResult SlideAdd()
        {
            ViewBag.cc = context.Sliders.Count();
            return View();
        }
        [HttpPost]
        public ActionResult SlideAdd(Slider t)
        {
            context.Sliders.Add(t);
            context.SaveChanges();
            return RedirectToAction("SlideAdd");
        }
    }
}