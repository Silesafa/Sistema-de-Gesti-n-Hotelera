using Proyecto1MVC.Models;

namespace Proyecto1MVC.Services
{
    public interface IHabitacionServices
    {
        IEnumerable<GestionHabitaciones> GetAll();
        GestionHabitaciones? GetByNumero(int numero);
        void Add(GestionHabitaciones habitacion);
        void Update(int numero, GestionHabitaciones habitacion);
        void Delete(int numero);

        //Metodo de Busqueda por num de hab
        GestionHabitaciones? BuscarPorNumeroHabitacion(int numero);

    }
}
