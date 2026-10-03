using System.ComponentModel.DataAnnotations;

namespace Proyecto1MVC.Models
{
    public class GestionClientes
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 3)]
        public string PrimerApellido { get; set; }

        [Required]
        [StringLength(75, MinimumLength = 3)]
        public string SegundoApellido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string TipoIdentificacion { get; set; } 
       
        [Required]
        [StringLength(50)]
        public string ClienteIdentificacion { get; set; }

     

    }
}
