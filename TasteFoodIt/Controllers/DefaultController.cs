using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Entities;
using TasteFoodIt.Context;

namespace TasteFoodIt.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        
        // GET: Default
        TasteContext context = new TasteContext();
        
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavBarInfo()
        {
            ViewBag.phone = context.Addresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.email = context.Addresses.Select(y => y.Email).FirstOrDefault();
            ViewBag.description = context.Addresses.Select(z => z.Description).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialSlider()
        {
            var value = context.Sliders.ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialAbout()
        {
            ViewBag.title = context.Abouts.Select(x => x.Title).FirstOrDefault();
            ViewBag.description = context.Abouts.Select(x => x.Description).FirstOrDefault();
            ViewBag.image = context.Abouts.Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public PartialViewResult PartialMenu()
        {
            var values = context.Products.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult PartialChef()
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialInfo()
        {
            return PartialView();
        }
        public PartialViewResult PartialReservationNow()
        {

            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            var value = context.openDayHours.ToList();
            return PartialView(value);
        }
        [HttpGet]
        public PartialViewResult PartialReservation()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialReservation(Reservation p)
        {
            var value = p;
            value.ReservationStatus = "Aktif";
            context.Reservations.Add(value);
            context.SaveChanges();
            return PartialView("PartialReservation");
        }
    }
}