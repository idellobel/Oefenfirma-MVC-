using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivo.OefenfirmaCMS.lib.Entities
{
    [Table("Andere Personen")]
    public class AnderePersonen : Gebruiker
    {
        [StringLength(50, ErrorMessage = "Het veld {0} mag niet langer zijn dan than 50 karakters.")]
        [Required]
        public string Hoedanigheid { get; set; }
    }
}
