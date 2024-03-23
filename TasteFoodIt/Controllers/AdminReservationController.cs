using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminReservationController : Controller
    {
        // GET: AdminReservation
        TasteContext context = new TasteContext();

        public ActionResult ReservationList()
        {
            var value = context.Reservations.ToList();
            return View(value);
        }
        public ActionResult DeleteReservation(int id)
        {
            var value = context.Reservations.Find(id);
            context.Reservations.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var value = context.Reservations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateReservationWait(Reservation t)
        {
            var value = context.Reservations.Find(t.ReservationId);
            value.Name = t.Name;
            value.Surname = t.Surname;
            value.Phone = t.Phone;
            value.ReservationDate = t.ReservationDate;
            value.Time = t.Time;
            value.GuestCount = t.GuestCount;
            value.Email = t.Email;
            value.ReservationStatus = "Beklemede";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpPost]
        public ActionResult UpdateReservationConfirm(Reservation t)
        {
            var value = context.Reservations.Find(t.ReservationId);
            value.Name = t.Name;
            value.Surname = t.Surname;
            value.Phone = t.Phone;
            value.ReservationDate = t.ReservationDate;
            value.Time = t.Time;
            value.GuestCount = t.GuestCount;
            value.Email = t.Email;
            value.ReservationStatus = "Onaylı";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpPost]
        public ActionResult UpdateReservationCancel(Reservation t)
        {
            var value = context.Reservations.Find(t.ReservationId);
            value.Name = t.Name;
            value.Surname = t.Surname;
            value.Phone = t.Phone;
            value.ReservationDate = t.ReservationDate;
            value.Time = t.Time;
            value.GuestCount = t.GuestCount;
            value.Email = t.Email;
            value.ReservationStatus = "İptal";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpGet]
        public ActionResult CreateReservation()
        {
            List<string> statusList = new List<string> { "Onaylandı", "Beklemede", "İptal Edildi" };
            ViewBag.ReservationStatus = new SelectList(statusList);
            return View();
        }
        [HttpPost]
        public ActionResult CreateReservation(Reservation t)
        {
            context.Reservations.Add(t);
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
    }
}