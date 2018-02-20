using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ivo.Oefenfirma.Web.ViewModels
{
    public class AuthentificationLoginVm
    {
        [StringLength(200, ErrorMessage = "De {0} mag niet langer zijn dan 200 karakters")]
        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(1000, ErrorMessage = "Het {0} mag niet langer zijn dan 1000 karakters")]
        [Display(Name = "Paswoord")]
        public string Password { get; set; }

        [Display(Name = "Onthou mij")]
        public bool RememberMe { get; set; }
    }
}