using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ivo.OefenfirmaCMS.lib.Entities
{
    public abstract class Gebruiker
    {

      

        [Key]
        [Required] //we maken eens géén gebruik van identity, maar van een GUID als key 
        public Guid GebruikerId { get; set; }
        //public long GebruikerId { get; set; }

        //[Required(ErrorMessage = "Het veld {0} is vereist")]
        //public string Gebruikersnaam { get; set; }

        //[Required(ErrorMessage = "Het veld {0} is vereist")]
        //public string PaswoordHash { get; set; } //wachtwoord bewaren als een versleutelde MD5 hash 

        [Required(ErrorMessage = "Het veld {0} is vereist")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Het veld {0} mag niet langer zijn dan than 50 karakters.")]
        [Display(Name = "FamilieNaam")]
        public string Familienaam { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Het veld {0} mag niet langer zijn dan than 50 karakters.")]
        [Column("Voornaam")]
        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }

        [Display(Name = "VolledigeNaam")]
        public string FullName
        {
            get { return Familienaam + ", " + Voornaam; }
        }

        [StringLength(70, ErrorMessage = "Het veld {0} mag niet langer zijn dan than 70 karakters.")]
        [Required(ErrorMessage = "Het veld {0} is vereist")]
        public string Adres { get; set; }


        [Required(ErrorMessage = "Het veld {0} is vereist")]
        public int Postcode { get; set; }

        [StringLength(30, ErrorMessage = "Het veld {0} mag niet langer zijn dan than 30 karakters.")]
        [Required(ErrorMessage = "Het veld {0} is vereist")]
        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Het veld {0} is vereist")]
        [Display(Name = "Telefoonnummer")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-8]{3})\)?[-. ]?([0-8]{3})[-. ]?([0-8]{4})$", ErrorMessage = "Geen geldig telefoonnummer")]
        public string PhoneNumber { get; set; }


    }

}


