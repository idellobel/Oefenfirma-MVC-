using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ivo.Oefenfirma.Web.ViewModels
{
    public class AccountRegisterVm
    {
        [Required(ErrorMessage = "Gelieve een gebruikersnaam te kiezen")]
        public string Gebruikersnaam { get; set; }

        [Required(ErrorMessage = "Gelieve een e-mailadres in te geven")]
        [EmailAddress(ErrorMessage = "Het opgegeven e-mailadres is niet geldig")]
        [Display(Name = "E-mailadres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gelieve een wachtwoord te kiezen")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string PaswoordEen { get; set; }

        [Display(Name = "Bevestig wachtwoord")]
        [DataType(DataType.Password)]
        [Compare("PaswoordEen", ErrorMessage = "De wachtwoorden komen niet overeen")]
        public string PaswoordTwee { get; set; }

        [Display(Name = "Ik ga akkoord met de voorwaarden")]
        public bool AkkoordMetVoorwaarden { get; set; }
    }
}