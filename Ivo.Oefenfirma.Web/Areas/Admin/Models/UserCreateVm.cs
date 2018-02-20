using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ivo.OefenfirmaCMS.lib.Entities;

namespace Ivo.Oefenfirma.Web.Areas.Admin.Models
{
    public class UserCreateVm
    {
        public User User { get; set; }
        public IEnumerable<SelectListItem> Rolelijst { get; set; }
    }
}