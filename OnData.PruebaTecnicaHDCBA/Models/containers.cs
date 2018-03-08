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
        [Display(Name = " Nombre del Contenido:")]
        [StringLength(50, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 1)]
        public string name { get; set; }


        
        [Display(Name = " Descripción del Contenido:")]
        [StringLength(50, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 1)]
        public string description { get; set; }

        public int type_container_id { get; set; }
        [Display(Name = " Tipo de Contenido:")]
        public virtual type_containers type_containers { get; set; }

        [Required]
        [Display(Name = "Contenido")]
        [StringLength(1000, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 1)]
        public string content { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }


        public virtual ICollection<containers_categories> containers_categories { get; set; }

    }
}