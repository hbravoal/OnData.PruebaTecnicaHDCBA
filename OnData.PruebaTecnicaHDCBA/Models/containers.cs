using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnData.PruebaTecnicaHDCBA.Models
{
    public class containers
    {
        [Key]
        public int id { get; set; }

        [Required]
        
        [StringLength(50, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 1)]
        public string name { get; set; }

        public int type_containers_id { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 1)]
        public string content { get; set; }

        public virtual type_containers type_containers { get; set; }

        public ICollection<containers_categories> containers_categories { get; set; }

    }
}