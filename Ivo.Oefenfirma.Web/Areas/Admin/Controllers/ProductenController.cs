using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Ivo.Oefenfirma.Web.Areas.Admin.Models;
using Ivo.OefenfirmaCMS.lib.Data;
using Ivo.OefenfirmaCMS.lib.Entities;
using Remotion.Logging;

namespace Ivo.Oefenfirma.Web.Areas.Admin.Controllers
{
    public class ProductenController : Controller
    {
        private IvoOefenfirmaContext db = new IvoOefenfirmaContext();

        // GET: Admin/Producten
        public ActionResult Index()
        {
            var producten = db.Producten.Include(p => p.Categorie)
                .Include(lv => lv.Leverancier);
              return View(producten.ToList());
        }

        // GET: Admin/Producten/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Producten.Include(i => i.Files).FirstOrDefault(i => i.Artikelnaam == id);
            Product product = db.Producten.Include(i => i.Files).Where(i => i.Artikelnummer == id).First();

            //Product product = db.Producten.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //private List<SelectListItem> hoofdcategorielijst()
        //{

        //    return
        //        db.Set<Categorie>()
        //             .Where(hc => hc.ParentId == hc.Id)
        //           .Select(hc => new SelectListItem
        //        { //transformeer elke hoofdcategorie naar een SelectListItem
        //            Value = hc.Id.ToString(),
        //            Text = hc.Categorienaam,
                   

        //        })
        //        .ToList();
            
            
        //}

        
        private List<SelectListItem> categorielijst()
        {
            
            return
                db.Set<Categorie>()
                     //.Where(c => c.Id == c.Id)
                   
                .Select(c => new SelectListItem
                { //transformeer elke categorie naar een SelectListItem
                    Value = c.Id.ToString(),
                    Text = c.Categorienaam

                })
                .ToList();
        }



        private List<SelectListItem> leverancierlijst()
        {

            return
                db.Set<Leverancier>()
                     .Where(lv => lv.LeverancierID == lv.LeverancierID)
                .Select(lv => new SelectListItem
                { //transformeer elke Leverancier naar een SelectListItem
                    Value = lv.LeverancierID.ToString(),
                    Text =lv.LeverancierNaam

                })
                .ToList();
        }

        // GET: Admin/Producten/Create
        public ActionResult Create()
        {
            var prodVm = new ProductCreateVm()
            {
                Product = null,
                //Hoofdcategorielijst = hoofdcategorielijst(),
                Leverancierlijst = leverancierlijst(),
                Categorielijst = categorielijst()
            };
            return View(prodVm);
        }

        // POST: Admin/Producten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreateVm inputProductCreateVm, HttpPostedFileBase upload)
        {
            var existingCategorie = db.Set<Categorie>().Find(inputProductCreateVm.Product.Categorie.Id);
            var existingLeverancier = db.Set<Leverancier>().Find(inputProductCreateVm.Product.Leverancier.GebruikerId);
            if (inputProductCreateVm.Product.Artikelnummer != null)
            {
                //nieuwe product maken
                var productToAdd = new Product
                {
                    Artikelnummer = inputProductCreateVm.Product.Artikelnummer,
                    Artikelnaam = inputProductCreateVm.Product.Artikelnaam,
                    Artikelomschrijving = inputProductCreateVm.Product.Artikelomschrijving,
                    Prijs     = inputProductCreateVm.Product.Prijs,
                    FiguurURL = inputProductCreateVm.Product.FiguurURL,
                    Spotlight = inputProductCreateVm.Product.Spotlight,
                    Categorie = existingCategorie,
                    Leverancier = existingLeverancier

                };
                if (ModelState.IsValid)
                {
                    if (upload != null && upload.ContentLength > 0)
                    {

                        var photo = new FilePaths
                        {
                            FileName = System.IO.Path.GetFileName(upload.FileName),
                            FileType = FileType.Photo,
                            Artikelnummer= upload.ToString(),
                        };
                        

                        productToAdd.Files = new List<FilePaths>();
                        productToAdd.Files.Add(photo);
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), upload.FileName));
                    }

                }

                //product tovoegen aan de dbSet (tabel)
                db.Set<Product>().Add(productToAdd);

                //context wijzigingen doorvoeren naar de Database
                db.SaveChanges();
                //actie voor response ondernemen
                TempData["SuccessMessage"] = $"Het product <b>{productToAdd.Artikelnummer}</b> werd toegevoegd!";
                return RedirectToAction("Index", new { Controller = "Producten", Area = "Admin" });
            }
            else
            {
                //de existing categorie of leverancier bestaat niet
                ModelState.AddModelError("Product.Categorie.Id",
                    $"De categorie met id {inputProductCreateVm.Product.Categorie.Id} bestaat niet!");
                ModelState.AddModelError("Product.Leverancier.GebruikerId",
                    $"De Leverancier met id {inputProductCreateVm.Product.Leverancier.GebruikerId} bestaat niet!");

            }
            //model not valid

            //input model wordt nu het view model, dus moet nog vervolledigd worden
            inputProductCreateVm = new ProductCreateVm()
            {
                Product = null,
                //Hoofdcategorielijst = hoofdcategorielijst(),
                Categorielijst =categorielijst(),
                Leverancierlijst = leverancierlijst()
            };

            return View(inputProductCreateVm);
        }


        // GET: Admin/Producten/Edit/5
        public ActionResult Edit(string id)
        {
          
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Producten.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
           
            return View(product);
        }

        // POST: Admin/Producten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Artikelnummer,Artikelnaam,Artikelomschrijving,Prijs,FiguurURL,Spotlight")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = $"Het product met <b>{product.Artikelnummer}</b> werd gewijzigd!";
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Admin/Producten/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Producten.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Producten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Producten.Find(id);
            db.Producten.Remove(product);
            db.SaveChanges();
            TempData["AlertMessage"] = $"Het product met <b>{product.Artikelnummer}</b> werd verwijderd!";
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
