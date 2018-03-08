using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        [Required]
        [Display(Name = " Descripción del Contenido:")]
        [StringLength(50, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 1)]
        public string description { get; set; }

        [Display(Name = " Tipo de Contenido:")]
        public int type_container_id { get; set; }

        
        public DateTime DatePublic { get; set; }

        public virtual type_containers type_containers { get; set; }


        [Display(Name = "Contenido")]
        [StringLength(1000, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 1)]
        public string content { get; set; }

        [DataType(DataType.ImageUrl)]
        public string image { get; set; }


        //public virtual ICollection<containers_categories> containers_categories { get; set; }

    }
}