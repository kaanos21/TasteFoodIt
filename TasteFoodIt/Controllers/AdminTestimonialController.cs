using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminTestimonialController : Controller
    {
        // GET: AdminTestimonial
        TasteContext context = new TasteContext();
        public ActionResult TestimonialList()
        {
            var value = context.Testimonials.ToList();
            return View(value);
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial t)
        {
            var value = context.Testimonials.Find(t.TestimonialId);
            value.NameSurname = t.NameSurname;
            value.Description = t.Description;
            value.Title = t.Title;
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial t)
        {
            context.Testimonials.Add(t);
            context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
    }
}