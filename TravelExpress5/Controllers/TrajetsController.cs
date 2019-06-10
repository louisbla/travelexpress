using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelExpress5.Models;

namespace TravelExpress5.Controllers
{
    public class TrajetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trajets
        public ActionResult Index()
        {
            string depart = Request["depart"];
            string arrivee = Request["arrivee"];
            string date = Request["date"];
            

            List<Trajet> trajets = db.Trajets.ToList();

            List<Trajet> trajetsDispo = new List<Trajet>();

            foreach (Trajet trajet in trajets)
            {
                if (trajet.NbPlacesLibres() != 0)
                    trajetsDispo.Add(trajet);
            }
            if (depart!= null)
            if (!depart.Equals("")) {
                trajetsDispo = trajetsDispo.Where(t => t.VilleDepart.Equals(depart)).ToList();
                    }
            if (arrivee != null)
                if (!arrivee.Equals(""))
            {
                trajetsDispo = trajetsDispo.Where(t => t.VilleArrivee.Equals(arrivee)).ToList();
            }
            if (date != null)
                if (!date.Equals(""))
                {
                    string[] time = date.Split('-');
                    trajetsDispo = trajetsDispo.Where(t => t.DateDepart.Year.ToString().Equals(time[0]))
                        .Where(t => t.DateDepart.Month ==  Convert.ToInt32(time[1]))
                        .Where(t => t.DateDepart.Day == Convert.ToInt32(time[2]))
                        .ToList();
                }

            return View(trajetsDispo);
        }

        // GET: Trajets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trajet trajet = db.Trajets.Find(id);
            if (trajet == null)
            {
                return HttpNotFound();
            }
            return View(trajet);
        }

        // GET: Trajets/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Trajets/MyReservations
        public ActionResult MyReservations()
        {
            IEnumerable<Reservation> reservations = db.Reservations.Where(r => r.Passager.Email.Equals(User.Identity.Name));

            return View(reservations);
        }

        // GET: Trajets/MesTrajets
        public ActionResult MesTrajets()
        {
            IEnumerable<Trajet> trajets = db.Trajets.Where(t => t.Conducteur.Email.Equals(User.Identity.Name));

            return View(trajets);
        }

        // POST: Trajets/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateDepart,NbPlacesMax,VilleDepart,VilleArrivee")] Trajet trajet)
        {
            if (ModelState.IsValid)
            {
                trajet.Conducteur = db.Users.Where(a => a.Email.Equals(User.Identity.Name)).First();
                db.Trajets.Add(trajet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trajet);
        }

        // GET: Trajets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trajet trajet = db.Trajets.Find(id);
            if (trajet == null)
            {
                return HttpNotFound();
            }
            return View(trajet);
        }

        // POST: Trajets/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateDepart,NbPlacesMax,VilleDepart,VilleArrivee")] Trajet trajet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trajet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trajet);
        }

        // GET: Trajets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trajet trajet = db.Trajets.Find(id);
            if (trajet == null)
            {
                return HttpNotFound();
            }
            return View(trajet);
        }

        // POST: Trajets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trajet trajet = db.Trajets.Find(id);
            db.Trajets.Remove(trajet);
            db.SaveChanges();
            return RedirectToAction("Index");
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
