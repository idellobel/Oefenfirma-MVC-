using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivo.OefenfirmaCMS.lib.Entities
{
   public class Product
    {
       [Key]
       [StringLength(20)]
       [Required]
       public string Artikelnummer { get; set; }

        [StringLength(512, ErrorMessage = "Het veld Artikelnaam kan niet langer zijn dan 512 karakters")]
        [Required (ErrorMessage = "Het veld Artikelnaam is vereist")]
        public string Artikelnaam { get; set; }

        [Required(ErrorMessage = "Het veld Artikelomschrijving is vereist")]
        public string Artikelomschrijving { get; set; }

       
        [Required(ErrorMessage = "Het veld Prijs is vereist")]
        [Display(Name = "Vkp Kleinh")]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Prijs { get; set; }

        [StringLength(512, ErrorMessage = "Het veld FiguurURL kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeelding")]

        public string FiguurURL { get; set; }

        public bool Spotlight { get; set; }

        public Categorie Categorie { get; set; }

        public Leverancier Leverancier { get; set; }

        public virtual ICollection<FilePaths> Files { get; set; }

    }
}
