using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivo.OefenfirmaCMS.lib.Entities
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200, ErrorMessage = "De {0} mag niet langer zijn dan 200 karakters")]
        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [Display(Name = "Gebruikersnaam")]
        public string Gebruikersnaam { get; set; }


        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(1000, ErrorMessage = "Het {0} mag niet langer zijn dan 1000 karakters")]
        [Display(Name = "Paswoord")]
        public string PaswoordHash { get; set; } //wachtwoord bewaren als een versleutelde MD5 hash 

        public bool RememberMe { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
