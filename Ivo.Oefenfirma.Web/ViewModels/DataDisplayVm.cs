using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Ivo.OefenfirmaCMS.lib.Entities;

namespace Ivo.Oefenfirma.Web.ViewModels
{
   
    public class DataDisplayVm
    {
        public IEnumerable<Categorie> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Gebruiker> Gebruikers { get; set; }
        public IEnumerable<AnderePersonen>  AnderePersonen { get; set; }
        public IEnumerable<Klant> Klanten { get; set; }
        public IEnumerable<Leverancier> Leveranciers { get; set; }

       

    }

  
}