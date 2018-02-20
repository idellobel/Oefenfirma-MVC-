using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Data.Entity;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Ivo.Oefenfirma.Web.ViewModels;
using Ivo.OefenfirmaCMS.lib.Data;
using Ivo.OefenfirmaCMS.lib.Entities;
using Remotion.Data.Linq.Clauses;

namespace Ivo.Oefenfirma.Web.Controllers
{
    public class HomeController : Controller
    {
        IvoOefenfirmaContext c = new IvoOefenfirmaContext();

        public ActionResult Index()

        {
            //IvoOefenfirmaContext c = new IvoOefenfirmaContext();
            var producten = c.Producten.Include(p => p.Categorie)
                .Include(lv => lv.Leverancier)
                .Where(p => p.Spotlight == true);
            return View(producten.ToList());

            //List<Product> products = c.Producten
            //    .Take(4)
            //    .ToList();
            //return View(products);

        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public ActionResult Contact()
        {
           
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ContactInfoResult(ContactinformatieVm input)
        {
            var info = input.Informatie;

            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Uw mail wordt zo vlug mogelijk behandeld!";
               
             
            }
            
            SmtpClient client = new SmtpClient("uit.telenet.be", 25);
            MailMessage message = new MailMessage("mailer@ivobrugge.be", "ivan.dellobel@gmail.com");
            message.Subject = "Een vraag van" + input.Naam;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Naam: {0}{1}", input.Naam, Environment.NewLine);
            sb.AppendFormat("Email: {0}{1}", input.Email, Environment.NewLine);
            sb.AppendFormat("Informatie: {0}{1}", input.Informatie, Environment.NewLine);


            message.Body = sb.ToString();
            client.Send(message);






            return RedirectToAction("Index", new { Controller = "Home" });
            //return View(input);




        }

           
        }
    }

