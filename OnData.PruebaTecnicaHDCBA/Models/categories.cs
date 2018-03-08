

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
        public string name { get; set; }

        public ICollection<containers_categories> containers_categories { get; set; }

    }
}