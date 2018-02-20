using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ivo.Oefenfirma.Web.ViewModels;
using Ivo.OefenfirmaCMS.lib.Data;
using Ivo.OefenfirmaCMS.lib.Entities;
using Ivo.OefenfirmaCMS.lib.Migrations;
using Ivo.OefenfirmaCMS.lib.Services;

namespace Ivo.Oefenfirma.Web.Controllers
{
    public class AccountController : Controller
    {
        private IvoOefenfirmaContext context;

        public AccountController()
        {
            context = new IvoOefenfirmaContext(); 
            
        }
        // GET: /Account/Register 
        public ActionResult Register()
        {
            AccountRegisterVm viewmodel = new AccountRegisterVm();
            return View(viewmodel);
        }

        // POST: /Account/Register 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountRegisterVm viewmodel)
        {
            if (ModelState.IsValid) //alles juist ingevuld? 
            {
                if (viewmodel.AkkoordMetVoorwaarden)
                {
                    try //we proberen de gebruiker toe te voegen 
                    {
                        User gebruiker = new User
                        {
                            Id = new long(),
                            Email = viewmodel.Email,
                            Gebruikersnaam = viewmodel.Gebruikersnaam,
                            PaswoordHash = FormsAuthentication.HashPasswordForStoringInConfigFile(viewmodel.PaswoordEen, "SHA1")
                               
                        };
                        context.User.Add(gebruiker);
                        context.SaveChanges();
                        TempData["SuccessMessage"] = "Je bent geregistreerd!";
                        return RedirectToAction("Index", "Home"); //terugsturen naar homepage
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", string.Format("Registratie gefaald: {0}.", ex.Message));
                    }
                }
                else
                {
                    ModelState.AddModelError("AkkoordMetVoorwaarden", 
                        "U dient akkoord te gaan met de voorwaarden");
                }
            } return View(viewmodel); //indien we hier uitkomen is er iets mislukt (validatie?) 
                                      //zelfde view tonen, maar reeds ingevuld met viewmodel gegevens 
        }
   






        private UserService userService = new UserService();

        // GET: Authentication
        public ActionResult Login()
        {
            AuthentificationLoginVm model = new AuthentificationLoginVm();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AuthentificationLoginVm inputmodel, string returnurl)
        {
            if (ModelState.IsValid)
            {
                User logged_in_user = userService.GetUserByUsernameAndPassword(inputmodel.UserName, inputmodel.Password);

                //check credentials
                if (userService.CheckCredentials(inputmodel.UserName, inputmodel.Password))
                {
                    //alle roles voor de huidige gebruiker ophalen
                    IEnumerable<string> rolenames = logged_in_user.Roles.Select<Role, string>(r => r.Name);
                    string rolesstring = string.Join(";", rolenames.ToArray());

                    //We maken onze eigen ticket aan zodat ook de roles bewaard kunnen worden (in de userdata property)
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                        1,                      // version
                        logged_in_user.Gebruikersnaam,// Gebruikersnaam
                        DateTime.Now,           // created
                        DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),    // expires
                        inputmodel.RememberMe,       // persistent?
                        rolesstring             // roles van deze user gescheiden door ;
                    );
                    //ticket encrypteren en in cookie zetten
                    string encryptedTicket = FormsAuthentication.Encrypt(ticket);
                    var authcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    Response.Cookies.Add(authcookie);

                    if (returnurl != null)
                    {
                        return Redirect(returnurl);
                    }
                    else
                    {
                        //redirect naar homepage
                        TempData["SuccessMessage"] = "Je bent ingelogd!";
                        return RedirectToAction("Index", "Home");
                    }
                }

                else
                { //ongeldige gebruikersnaam of wachtwoord
                    //voeg een foutboodschap toe (wanneer key == "", dan hoort deze niet bij een bepaalde property)
                    ModelState.AddModelError("", "De ingevoerde gebruikersnaam of wachtwoord is ongeldig");
                    //aanmeldingscherm opnieuw tonen
                    return View(inputmodel);
                }

            }
            else
            {
                //onvolledige gegevens, toon formulier opnieuw
                return View(inputmodel);
            }

            ////inloggen door een authenticatie cookie te plaatsen op client
            //FormsAuthentication.SetAuthCookie("Admin", userService.CheckCredentials(inputmodel.UserName,inputmodel.Password));
                   
            //        return RedirectToAction("Index", new { Controller = "Home" });
            //    }
            //    else
            //    {
            //        //ongeldige gebruikersnaam of wachtwoord
            //        ModelState.AddModelError("", new Exception("U voerde een ongeldige gebruikersnaam of paswoord in!"));
            //        return View(inputmodel);
            //    }
            //}

            //else {
            //    //onvolledige gegevens, toon formulier opnieuw
            //    return View(inputmodel);
            //}
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); //betekenis: server stuurt cookie naar browser die het login-cookie overschrijft.
            return RedirectToAction("Index", "Home"); // Server kan de browser immers zomaar niet beïnvloeden.
        }


    }
}

