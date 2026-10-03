using System.ComponentModel.DataAnnotations;

namespace Proyecto1MVC.Models
{
    public class GestionEmpleados
    {
        [Required]
        [StringLength(12)]
        public string EmpleadoIdentificacion { get; set; }

        [Required]
        public string TipoIdentificacion { get; set; }

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
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; }

        [Required]
        [StringLength(30)]
        public string Categoria { get; set; }

        [Range(0, 5000000, ErrorMessage = "El salario debe estar entre 0 y 5,000,000")]
        public decimal Salario { get; set; }

        [Required]
        public string Provincia { get; set; }

        [Required]
        public string Canton { get; set; }

        [Required]
        public string Distrito { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 1)]
        public string DireccionExacta { get; set; }
    }
}

