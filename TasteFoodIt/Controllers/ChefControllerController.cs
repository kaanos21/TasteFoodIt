using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class ChefControllerController : Controller
    {
        // GET: ChefController
        TasteContext context = new TasteContext();


        public ActionResult ChefList()
        {
            var value = context.Chefs.ToList();
            return View(value);
        }

        public ActionResult DeleteChef(int id)
        {
            var value = context.Chefs.Find(id);
            context.Chefs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = context.Chefs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChef(Chef t)
        {
            var value = context.Chefs.Find(t.ID);
            value.NameSurname = t.NameSurname;
            value.Description = t.Description;
            value.Title = t.Title;
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
        [HttpGet]
        public ActionResult CreateChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateChef(Chef t)
        {
            context.Chefs.Add(t);
            context.SaveChanges();
            return RedirectToAction("ChefList");
        }
    }
}