using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ivo.Oefenfirma.Web.ViewModels;
using Ivo.OefenfirmaCMS.lib.Data;
using Ivo.OefenfirmaCMS.lib.Entities;

namespace Ivo.Oefenfirma.Web.Controllers
{
    public class DataDisplayController : Controller
    {
        private IvoOefenfirmaContext db = new IvoOefenfirmaContext();
        // GET: DataDisplay
        public ActionResult Index()
        {
            
            var vm = new DataDisplayVm
            {
                Categories = db.Categorieen.ToList(),
                Products = db.Producten.ToList(),
                Gebruikers = db.Gebruikers.ToList(),
                AnderePersonen = db.AnderePersonen.ToList(),
                Klanten = db.Klanten.ToList(),
                Leveranciers = db.Leveranciers.ToList(),

                
        };
            

            return View(vm);
        }
    }
}