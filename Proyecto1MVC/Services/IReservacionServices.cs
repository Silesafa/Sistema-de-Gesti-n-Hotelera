using Proyecto1MVC.Models;

namespace Proyecto1MVC.Services
{
    public interface IReservacionServices
    {
        IEnumerable<GestionReservaciones> GetAll();
        GestionReservaciones? GetByCodigo(string codigo);
        void Add(GestionReservaciones reservacion);
        void Update(string codigoOriginal, GestionReservaciones reservacionActualizada);
        void Delete(string codigo);

        // Métodos de busqueda por cod y por ID Cliente
        GestionReservaciones? BuscarPorCodigo(string codigo);
        GestionReservaciones? BuscarPorCliente(string clienteId);
    }
}




