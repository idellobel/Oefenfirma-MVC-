using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ivo.Oefenfirma.Web.Controllers
{
    public class MandjeController : Controller
    {
        // GET: Mandje
        public ActionResult Index()
        {
            return View();
        }

        // GET: Mandje/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Mandje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mandje/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mandje/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Mandje/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Mandje/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Mandje/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
