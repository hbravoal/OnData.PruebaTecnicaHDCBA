using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnData.PruebaTecnicaHDCBA.Models
{
    [NotMapped]
    public class containerView :containers
    {
        [Display(Name = "Imagen:")]
        public HttpPostedFileBase LogoFile { get; set; }
    }
}