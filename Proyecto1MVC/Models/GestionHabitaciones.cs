using System.ComponentModel.DataAnnotations;
namespace Proyecto1MVC.Models
{
    public class GestionHabitaciones
    {
        [Required]
        [Range(1, 500, ErrorMessage = "El número de habitación debe estar entre 1 y 500.")]
        public int NumeroHabitacion { get; set; }

        [Required]
        [Display(Name = "Tipo de Habitación")]
        [RegularExpression("^(Start Junior|Start Vista al Mar|Master Start)$",
            ErrorMessage = "El tipo de habitación debe ser: Start Junior, Start Vista al Mar o Master Start.")]

        public string TipoHabitacion { get; set; }

        [Required]
        [Range(50, 800, ErrorMessage = "La tarifa debe estar entre 50 y 800 dólares.")]
        public decimal TarifaPorNoche { get; set; }

        [Display(Name = "TV Satelital")]
        public bool TVSatelital { get; set; }

        [StringLength( 500, ErrorMessage = "Máximo 500 caracteres.")]
        [Display(Name = "Pendientes de Mantenimiento")]
        public string PendientesMantenimiento { get; set; }
    }
}

