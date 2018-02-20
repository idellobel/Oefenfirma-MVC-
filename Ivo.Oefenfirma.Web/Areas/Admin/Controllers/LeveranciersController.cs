using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ivo.OefenfirmaCMS.lib.Data;
using Ivo.OefenfirmaCMS.lib.Entities;

namespace Ivo.Oefenfirma.Web.Areas.Admin.Controllers
{
    public class LeveranciersController : Controller
    {
        private IvoOefenfirmaContext db = new IvoOefenfirmaContext();

        // GET: Admin/Leveranciers
        public ActionResult Index()
        {
            return View(db.Leveranciers.ToList());
        }

        // GET: Admin/Leveranciers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leverancier leverancier = db.Leveranciers.Find(id);
            if (leverancier == null)
            {
                return HttpNotFound();
            }
            return View(leverancier);
        }

        // GET: Admin/Leveranciers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Leveranciers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GebruikerId,Gebruikersnaam,PaswoordHash,Email,Familienaam,Voornaam,Adres,Postcode,Gemeente,PhoneNumber,LeverancierDatum,LeverancierID,LeverancierNaam")] Leverancier leverancier)
        {
            if (ModelState.IsValid)
            {
                leverancier.GebruikerId = Guid.NewGuid();
                db.Gebruikers.Add(leverancier);
                db.SaveChanges();
                TempData["SuccessMessage"] = $"De leverancier met naam <b>{leverancier.FullName}</b> werd toegevoegd!";
                return RedirectToAction("Index");
            }

            return View(leverancier);
        }

        // GET: Admin/Leveranciers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leverancier leverancier = db.Leveranciers.Find(id);
            if (leverancier == null)
            {
                return HttpNotFound();
            }
            return View(leverancier);
        }

        // POST: Admin/Leveranciers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GebruikerId,Gebruikersnaam,PaswoordHash,Email,Familienaam,Voornaam,Adres,Postcode,Gemeente,PhoneNumber,LeverancierDatum,LeverancierID,LeverancierNaam")] Leverancier leverancier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leverancier).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = $"De leverancier met naam <b>{leverancier.FullName}</b> werd gewijzigd!";
                return RedirectToAction("Index");
            }
            return View(leverancier);
        }

        // GET: Admin/Leveranciers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leverancier leverancier = db.Leveranciers.Find(id);
            if (leverancier == null)
            {
                return HttpNotFound();
            }
            return View(leverancier);
        }

        // POST: Admin/Leveranciers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Leverancier leverancier = db.Leveranciers.Find(id);
            db.Gebruikers.Remove(leverancier);
            db.SaveChanges();
            TempData["AlertMessage"] = $"De leverancier met naam <b>{leverancier.FullName}</b> werd verwijderd!";
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
