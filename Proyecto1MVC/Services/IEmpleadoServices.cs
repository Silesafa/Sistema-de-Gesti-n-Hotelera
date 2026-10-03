using Proyecto1MVC.Models;

namespace Proyecto1MVC.Services
{
    public interface IEmpleadoService
    {
        IEnumerable<GestionEmpleados> GetAll();
        GestionEmpleados? GetById(string id);
        void Add(GestionEmpleados empleado);
        void Update(string id, GestionEmpleados empleado);
        void Delete(string id);

        // Método de búsqueda por ID
        GestionEmpleados? BuscarPorIdentificacion(string id);
    }
}

