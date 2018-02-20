using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ivo.OefenfirmaCMS.lib.Entities
{
    
   public class Categorie
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vul een {0} in.")]
        [Display(Name = "Categorie")]
        public string Categorienaam { get; set; }

        public int? ParentId { get; set; }

      
        public virtual Categorie Parent { get; set; }

        [Display(Name = "Hoofdcategorie")]
        public virtual ICollection<Categorie> Children { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        //public Categorie()
        //{
        //    this.SubCategories = new HashSet<Categorie>();
        //    this.Products = new HashSet<Product>();
        //}

    }

}
