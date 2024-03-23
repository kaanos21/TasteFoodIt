using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TasteFoodIt.Context;
using TasteFoodIt.Entities;

namespace TasteFoodIt.Controllers
{
    public class AdminSocialMediaController : Controller
    {
        // GET: AdminSocialMedia
        TasteContext context = new TasteContext();

        public ActionResult SocialMediaList()
        {
            var value = context.socialMedias.ToList();
            return View(value);
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var value = context.socialMedias.Find(id);
            context.socialMedias.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = context.socialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia t)
        {
            var value = context.socialMedias.Find(t.SocialMediaId);
            value.PlatformName = t.PlatformName;
            value.IconUrl = t.IconUrl;
            value.RedirectUrl = t.RedirectUrl;
            context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}