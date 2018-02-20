using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ivo.OefenfirmaCMS.lib.Entities;

namespace Ivo.Oefenfirma.Web.Areas.Admin.Models
{
    public class CategorieCreateVm
    {
        

        public Categorie Categorie { get; set; }

        public IEnumerable<SelectListItem> Hoofdcategorielijst { get; set; }
    }
}