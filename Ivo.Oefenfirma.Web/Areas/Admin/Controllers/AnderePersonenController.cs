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
    public class AnderePersonenController : Controller
    {
        private IvoOefenfirmaContext db = new IvoOefenfirmaContext();

        // GET: Admin/AnderePersonen
        public ActionResult Index()
        {
            return View(db.AnderePersonen.ToList());
        }

        // GET: Admin/AnderePersonen/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnderePersonen anderePersonen = db.AnderePersonen.Find(id);
            if (anderePersonen == null)
            {
                return HttpNotFound();
            }
            return View(anderePersonen);
        }

        // GET: Admin/AnderePersonen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AnderePersonen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GebruikerId,Gebruikersnaam,PaswoordHash,Email,Familienaam,Voornaam,Adres,Postcode,Gemeente,PhoneNumber,Hoedanigheid")] AnderePersonen anderePersonen)
        {
            if (ModelState.IsValid)
            {
                anderePersonen.GebruikerId = Guid.NewGuid();
                db.Gebruikers.Add(anderePersonen);
                db.SaveChanges();
                TempData["SuccessMessage"] = $"De 'AnderePersoon' met naam <b>{anderePersonen.FullName}</b> werd toegevoegd!";
                return RedirectToAction("Index");
            }

            return View(anderePersonen);
        }

        // GET: Admin/AnderePersonen/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnderePersonen anderePersonen = db.AnderePersonen.Find(id);
            if (anderePersonen == null)
            {
                return HttpNotFound();
            }
            return View(anderePersonen);
        }

        // POST: Admin/AnderePersonen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GebruikerId,Gebruikersnaam,PaswoordHash,Email,Familienaam,Voornaam,Adres,Postcode,Gemeente,PhoneNumber,Hoedanigheid")] AnderePersonen anderePersonen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anderePersonen).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = $"De 'AnderePersoon' met naam <b>{anderePersonen.FullName}</b> werd gewijzigd!";
                return RedirectToAction("Index");
            }
            return View(anderePersonen);
        }

        // GET: Admin/AnderePersonen/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnderePersonen anderePersonen = db.AnderePersonen.Find(id);
            if (anderePersonen == null)
            {
                return HttpNotFound();
            }
            return View(anderePersonen);
        }

        // POST: Admin/AnderePersonen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AnderePersonen anderePersonen = db.AnderePersonen.Find(id);
            db.Gebruikers.Remove(anderePersonen);
            db.SaveChanges();
            TempData["AlertMessage"] = $"De 'AnderePersoon' met naam <b>{anderePersonen.FullName}</b> werd verwijderd!";
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
