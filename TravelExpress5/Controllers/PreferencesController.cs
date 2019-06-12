using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelExpress5.Models;

namespace TravelExpress5.Controllers
{
    public class PreferencesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Preferences
        public ActionResult Index()
        {
            ApplicationUser user = db.Users.Where(u => u.Email.Equals(User.Identity.Name)).Include(t => t.Preferences).First();
            
            return View(user);
        }

        // GET: Preferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Preferences preferences = db.Preferences.Find(id);
            if (preferences == null)
            {
                return HttpNotFound();
            }
            return View(preferences);
        }

        // POST: Preferences/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PrefFumeur,PrefAnimaux,PrefDiscussion,PrefMusique")] Preferences preferences)
        {
            if (ModelState.IsValid)
            {
                db.Entry(preferences).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }
            return View(preferences);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
