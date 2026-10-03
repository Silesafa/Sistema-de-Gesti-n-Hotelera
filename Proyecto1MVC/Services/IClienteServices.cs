using Proyecto1MVC.Models;

namespace Proyecto1MVC.Services
{
    public interface IClienteServices
    {
        IEnumerable<GestionClientes> GetAll();
        GestionClientes GetById(string identificacion);
        void Add(GestionClientes cliente);
        void Update(string id, GestionClientes cliente);
        void Delete(string id);

        // Método de busqueda por ID
        GestionClientes? BuscarPorIdentificacion(string id);
    }
}

