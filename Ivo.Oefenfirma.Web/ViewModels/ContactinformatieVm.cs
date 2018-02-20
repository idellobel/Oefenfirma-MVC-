using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ivo.Oefenfirma.Web.ViewModels
{
    public class ContactinformatieVm
    {
        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(1000, ErrorMessage = "Het {0} mag niet langer zijn dan 200 karakters")]
        public string Naam { get; set;}

        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(1000, ErrorMessage = "Het {0} mag niet langer zijn dan 300 karakters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(1000, ErrorMessage = "Het {0} mag niet langer zijn dan 1500 karakters")]
        public string Informatie { get; set; }
    }
}