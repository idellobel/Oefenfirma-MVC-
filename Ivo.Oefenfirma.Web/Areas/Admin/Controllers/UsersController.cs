using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ivo.Oefenfirma.Web.Areas.Admin.Models;
using Ivo.OefenfirmaCMS.lib.Data;
using Ivo.OefenfirmaCMS.lib.Entities;

namespace Ivo.Oefenfirma.Web.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private IvoOefenfirmaContext db = new IvoOefenfirmaContext();

        // GET: Admin/Users
        public ActionResult Index()
        {
            var users = db.User.Include("Roles");
               
            return View(users.ToList());
            //return View(db.User.ToList());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User
                .Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        private List<SelectListItem> rolelijst()
        {

            return
                db.Set<Role>()
              
                .Select(r => new SelectListItem
                { //transformeer elke role naar een SelectListItem
                    Value = r.RoleId.ToString(),
                    Text = r.Name

                })
                .ToList();
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            var userVm = new UserCreateVm()
            {
               Rolelijst = rolelijst()
            };
            return View(userVm);
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Gebruikersnaam,PaswoordHash,RememberMe,Email,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                TempData["SuccessMessage"] = $"De klant met naam <b>{user.Gebruikersnaam}</b> werd toegevoegd!";
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Gebruikersnaam,PaswoordHash,RememberMe,Email,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = $"De klant met naam <b>{user.Gebruikersnaam}</b> werd gewijzigd!";
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            TempData["AlertMessage"] = $"De klant met naam <b>{user.Gebruikersnaam}</b> werd verwijderd!";
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
