
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnData.PruebaTecnicaHDCBA.Models
{
    [NotMapped]
    public class UserEmailView : containers
    {
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }
    }
}