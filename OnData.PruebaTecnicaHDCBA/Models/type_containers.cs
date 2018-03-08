
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OnData.PruebaTecnicaHDCBA.Models
{
    public class type_containers
    {
        [Key]
        public int id { get; set; }

        [Required]
        
        [StringLength(50, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 1)]
        [Display(Name = " Tipo de Contenido:")]
        public string type { get; set; }
        public virtual ICollection<containers> containers { get; set; }

    }
}