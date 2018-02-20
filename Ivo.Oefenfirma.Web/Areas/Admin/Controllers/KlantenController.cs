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
    public class KlantenController : Controller
    {
        private IvoOefenfirmaContext db = new IvoOefenfirmaContext();

        // GET: Admin/Klanten
        public ActionResult Index()
        {
            return View(db.Klanten.ToList());
        }

        // GET: Admin/Klanten/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klant klant = db.Klanten.Find(id);
            if (klant == null)
            {
                return HttpNotFound();
            }
            return View(klant);
        }

        // GET: Admin/Klanten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Klanten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GebruikerId,Gebruikersnaam,PaswoordHash,Email,Familienaam,Voornaam,Adres,Postcode,Gemeente,PhoneNumber,KlantDatum,KlantID,KlantNaam")] Klant klant)
        {
            if (ModelState.IsValid)
            {
                klant.GebruikerId = Guid.NewGuid();
                db.Gebruikers.Add(klant);
                db.SaveChanges();
                TempData["SuccessMessage"] = $"De klant met naam <b>{klant.FullName}</b> werd toegevoegd!";
                return RedirectToAction("Index");
            }

            return View(klant);
        }

        // GET: Admin/Klanten/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klant klant = db.Klanten.Find(id);
            if (klant == null)
            {
                return HttpNotFound();
            }
            return View(klant);
        }

        // POST: Admin/Klanten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GebruikerId,Gebruikersnaam,PaswoordHash,Email,Familienaam,Voornaam,Adres,Postcode,Gemeente,PhoneNumber,KlantDatum,KlantID,KlantNaam")] Klant klant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klant).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = $"De klant met naam <b>{klant.FullName}</b> werd gewijzigd!";
                return RedirectToAction("Index");
            }
            return View(klant);
        }

        // GET: Admin/Klanten/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klant klant = db.Klanten.Find(id);
            if (klant == null)
            {
                return HttpNotFound();
            }
            return View(klant);
        }

        // POST: Admin/Klanten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Klant klant = db.Klanten.Find(id);
            db.Gebruikers.Remove(klant);
            db.SaveChanges();
            TempData["AlertMessage"] = $"De klant met naam <b>{klant.FullName}</b> werd verwijderd!";
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
