using System.ComponentModel.DataAnnotations;

namespace Proyecto1MVC.Models
{
    public class GestionReservaciones
    {
        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El código debe tener entre 1 y 20 caracteres.")]
        public string CodigoReservacion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un cliente registrado.")]
        public string ClienteIdentificacion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una habitación registrada.")]
        public int NumeroHabitacion { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(GestionReservaciones), nameof(ValidarFechaSalida))]
        public DateTime FechaSalida { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "La cantidad de personas debe estar entre 1 y 10.")]
        public int CantidadPersonas { get; set; }

        [Required]
        [RegularExpression("^(Reservada|Confirmada|Cancelada|Completada)$",
            ErrorMessage = "El estado debe ser: Reservada, Confirmada, Cancelada o Completada.")]
        public string EstadoReservacion { get; set; }

        // Validación personalizada para asegurar que la fecha de salida sea posterior a la de ingreso
        public static ValidationResult ValidarFechaSalida(DateTime fechaSalida, ValidationContext context)
        {
            var instance = context.ObjectInstance as GestionReservaciones;
            if (instance != null && fechaSalida <= instance.FechaIngreso)
            {
                return new ValidationResult("La fecha de salida debe ser posterior a la fecha de ingreso.");
            }
            return ValidationResult.Success;
        }
    }
}
