using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using System.Security.Principal;
using System.Web.Security;
using Ivo.OefenfirmaCMS.lib.Data;

namespace Ivo.Oefenfirma.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer<IvoOefenfirmaContext>(new IvoOefenfirmaInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        /// <summary>
        ///  Het Authorize attribuut zoekt naar betreffende Roles van de geauthenticeerde gebruiker.
        ///  Deze Roles bevinden zich normaal gezien in het User.Identity object. 
        ///  Om het Authorize attribuut te kunnen benutten moeten we er dus voor zorgen dat de roles daarin terecht komen. 
        /// *** Een ideale plaats om het User.Identity object te wijzigen alvorens de request naar de controller wordt gestuurd 
        /// is het event Application_AuthenticateRequest.We declaren dit event in de Global.asax code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        //a. We controleren of de gebruiker daadwerkelijk is ingelogd met IsAuthenticated.
                        // Get Forms Identity From Current User
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        //b. We lezen het FormsAuthenticationTicket, deze bevat immers de roles van de gebruiker toen hij zich aanmeldde.
                        // Get Forms Ticket From Identity object
                        FormsAuthenticationTicket ticket = id.Ticket;

                        // Retrieve stored user-data (our roles from db)
                        string userData = ticket.UserData;
                        string[] roles = userData.Split(';');
                        //c. We kennen een nieuw Principal object toe, ditmaal met de rolenamen die aan deze gebruiker werden toegekend.
                        // Create a new Generic Principal Instance and assign to Current User
                        HttpContext.Current.User = new GenericPrincipal(id, roles);
                    }
                }
            }
        }
    }
}
