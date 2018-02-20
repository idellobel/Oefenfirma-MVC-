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
    public class CategoriesController : Controller
    {
        private IvoOefenfirmaContext db = new IvoOefenfirmaContext();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            var categorieen = db.Categorieen.Include(c => c.Parent).Include(p => p.Products);
            return View(categorieen.ToList());
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categorieen.Find(id);
            if (categorie.Categorienaam == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        private List<SelectListItem> hoofdcategorielijst()
        {
            
            return
                db.Set<Categorie>()
                     .Where(hc => hc.ParentId == hc.Id)
                .Select(hc => new SelectListItem
                { //transformeer elke hoofdcategorie naar een SelectListItem
                    Value = hc.Id.ToString(),
                    Text = hc.Categorienaam

                })
                .ToList();
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            //ViewBag.ParentId = new SelectList(db.Categorieen, "Id", "Categorienaam");
            

            var vm = new CategorieCreateVm()
            {
                Categorie = null,
                Hoofdcategorielijst = hoofdcategorielijst()
            };


            return View(vm);
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult Create(CategorieCreateVm inputCategorieCreateVm)
            {
                if (inputCategorieCreateVm.Categorie.Categorienaam != null) //zo ja,
                {
                    //nieuwe categorie maken
                    var categorieToAdd = new Categorie
                    {
                        Categorienaam = inputCategorieCreateVm.Categorie.Categorienaam,
                        ParentId = inputCategorieCreateVm.Categorie.ParentId,

                    };

                    //categorie tovoegen aan de dbSet (tabel)
                    db.Set<Categorie>().Add(categorieToAdd);

                    //context wijzigingen doorvoeren naar de Database
                    db.SaveChanges();
                //actie voor response ondernemen
                TempData["SuccessMessage"] = $"De categorie <b>{categorieToAdd.Categorienaam}</b> werd toegevoegd!";
                return RedirectToAction("Index", new { Controller = "Categories", Area = "Admin" });
            }
            else
            {
                //de existing categorie bestaat niet
                ModelState.AddModelError("Categorie.ParentId",
                    $"De categorie met id {inputCategorieCreateVm.Categorie.ParentId} bestaat niet!");
               

            }
            //model not valid

            //input model wordt nu het view model, dus moet nog vervolledigd worden
            inputCategorieCreateVm = new CategorieCreateVm()
            {
                Categorie = null,
                Hoofdcategorielijst = hoofdcategorielijst()
            };

            return View(inputCategorieCreateVm);





            }
           

            // GET: Admin/Categories/Edit/5
            public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categorieen.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.Categorieen, "Id", "Categorienaam", categorie.ParentId);
            return View(categorie);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Categorienaam,ParentId")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.Categorieen, "Id", "Categorienaam", categorie.ParentId);
            return View(categorie);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categorie categorie = db.Categorieen.Find(id);
            if (categorie == null)
            {
                return HttpNotFound();
            }
            return View(categorie);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categorie categorie = db.Categorieen.Find(id);

            if (categorie.Children.Count() == 0)
            {
                if (categorie.Products.Count() == 0)
                {
                    try
                    {
                        db.Categorieen.Remove(categorie);
                        db.SaveChanges();

                        TempData["SuccessMessage"] = $"De <b>{categorie.Categorienaam}</b> is succesvol verwijderd.";
                        //TempData["msgClass"] = "alert alert-success";
                    }
                    catch
                    {
                        TempData["AlertMessage"] = $"De <b>{categorie.Categorienaam}</b> kon niet verwijderd worden.";
                        //TempData["msgClass"] = "alert alert-danger";
                    }
                }
                else
                {
                    TempData["AlertMessage"] = $"De <b>{categorie.Categorienaam}</b> kon niet verwijderd worden (bevat producten).";
                    //TempData["msgClass"] = "alert alert-danger";<b>{categorie.Categorienaam}</b>
                }
            }
            else
            {
                TempData["AlertMessage"] = $"De <b>{categorie.Categorienaam}</b> kon niet verwijderd worden.";
                //TempData["msgClass"] = "alert alert-danger";
            }



            //db.Categorieen.Remove(categorie);
            //db.SaveChanges();
            //TempData["SuccessMessage"] = $"De categorie <b>{categorie.Categorienaam}</b> werd verwijderd!";
           
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
