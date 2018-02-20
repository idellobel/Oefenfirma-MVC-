using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ivo.OefenfirmaCMS.lib.Data;
using Ivo.OefenfirmaCMS.lib.Entities;
using Microsoft.Ajax.Utilities;
using Remotion.Data.Linq.Clauses;

namespace Ivo.Oefenfirma.Web.Controllers
{
    public class WinkelController : Controller
    {
         private IvoOefenfirmaContext db = new IvoOefenfirmaContext();

        // GET: Winkel
        public ActionResult Index()
        {
            var categorieen = db.Categorieen
                .Include(p => p.Products)
                .Include(hc => hc.Children)
                .Where(c => c.ParentId != c.Id);
            

            return View(categorieen.ToList());
        }

        //Get: Winkel/Producten
        public ActionResult Producten(string categorie)
        {
            Categorie cat = db.Categorieen
                .Include(p => p.Products)
                .FirstOrDefault(ct => ct.Categorienaam == categorie);
            return View(cat);
        }



        // GET: Winkel/Details/5
        public ActionResult Details(string id)
        {
          
            Product product = db.Producten
                .Include(c => c.Categorie)
                .FirstOrDefault(p => p.Artikelnummer == id);

            return View(product);
        }

        

       

      
    }
}
