using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivo.OefenfirmaCMS.lib.Entities
{
    [Table("Leverancier")]

    public class Leverancier : Gebruiker
    {
        [Required(ErrorMessage = "Het veld {0} is vereist")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Leverancier sedert")]
        public DateTime LeverancierDatum { get; set; }

        //[ForeignKey("Leverancier")]
        [Required(ErrorMessage = "Het veld {0} is vereist")]
        public long LeverancierID { get; set; }

        [Required(ErrorMessage = "Het veld {0} is vereist")]
        [StringLength(50, ErrorMessage = "Het veld {0} mag niet langer zijn dan than 50 karakters.")]
        [Display(Name = "LeverancierNaam")]
        public string LeverancierNaam { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        
    }

}
