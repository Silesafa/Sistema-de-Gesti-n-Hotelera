using Proyecto1MVC.Models;

namespace Proyecto1MVC.Services
{
    public class HabitacionService : IHabitacionServices
    {
        private static List<GestionHabitaciones> habitaciones = new List<GestionHabitaciones>();

        public IEnumerable<GestionHabitaciones> GetAll() => habitaciones;

        public GestionHabitaciones? GetByNumero(int numero) =>
            habitaciones.FirstOrDefault(h => h.NumeroHabitacion == numero);

        public void Add(GestionHabitaciones habitacion)
        {
            if (habitaciones.Any(h => h.NumeroHabitacion == habitacion.NumeroHabitacion))
            {
                throw new InvalidOperationException("Ese número de habitación ya está registrado.");
            }
            habitaciones.Add(habitacion);
        }

        public void Update(int numeroOriginal, GestionHabitaciones habitacionActualizada)
        {
            var existente = GetByNumero(numeroOriginal);
            if (existente != null)
            {
               
                existente.NumeroHabitacion = habitacionActualizada.NumeroHabitacion;
                existente.TipoHabitacion = habitacionActualizada.TipoHabitacion;
                existente.TarifaPorNoche = habitacionActualizada.TarifaPorNoche;
                existente.TVSatelital = habitacionActualizada.TVSatelital;
                existente.PendientesMantenimiento = habitacionActualizada.PendientesMantenimiento;
            }
        }



        public void Delete(int numero)
        {
            var existente = GetByNumero(numero);
            if (existente != null) habitaciones.Remove(existente);
        }
        public GestionHabitaciones? BuscarPorNumeroHabitacion(int numero)
        {
            return habitaciones.FirstOrDefault(h => h.NumeroHabitacion == numero);
        }


    }

}

