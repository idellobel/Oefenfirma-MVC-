using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivo.OefenfirmaCMS.lib.Entities
{
    [Table("Klant")]

    public class Klant : Gebruiker
    {
        [Required(ErrorMessage = "Het veld {0} is vereist")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Klant sedert")]
        public DateTime KlantDatum { get; set; }


        [Required(ErrorMessage = "Het veld {0} is vereist")]
        public long KlantID { get; set; }

        [Required(ErrorMessage = "Het veld {0} is vereist")]
        [StringLength(50, ErrorMessage = "Het veld {0} mag niet langer zijn dan than 50 karakters.")]
        [Display(Name = "KlantNaam")]
        public string KlantNaam { get; set; }


       
    }
}
