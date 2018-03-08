

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnData.PruebaTecnicaHDCBA.Models
{
    public class categories
    {

        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "{0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 1)]
        [Display(Name = " Nombre de Categoria:")]
        public string category { get; set; }

        //public virtual ICollection<containers_categories> containers_categories { get; set; }

    }
}