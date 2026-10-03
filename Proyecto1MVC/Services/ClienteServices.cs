using Proyecto1MVC.Models;

namespace Proyecto1MVC.Services
{
    public class ClienteService : IClienteServices
    {
        private static List<GestionClientes> clientes = new List<GestionClientes>(); //crea la lista 

        public IEnumerable<GestionClientes> GetAll() => clientes;

        public GestionClientes? GetById(string id) =>                     //se obtiene cliente por ID
            clientes.FirstOrDefault(c => c.ClienteIdentificacion == id);

        public void Add(GestionClientes cliente) => clientes.Add(cliente);  //agregar cliente

        public void Update(string id, GestionClientes clienteActualizado)   //actualizar datos del cliente
        {
            var existente = GetById(id);
            if (existente != null)
            {
                existente.Nombre = clienteActualizado.Nombre;
                existente.PrimerApellido = clienteActualizado.PrimerApellido;
                existente.SegundoApellido = clienteActualizado.SegundoApellido;
                existente.FechaNacimiento = clienteActualizado.FechaNacimiento;
                existente.TipoIdentificacion = clienteActualizado.TipoIdentificacion;
                existente.ClienteIdentificacion = clienteActualizado.ClienteIdentificacion;
            }
        }


        public void Delete(string id)        //borrar 
        {
            var existente = GetById(id);
            if (existente != null)
                clientes.Remove(existente);
        }

        public GestionClientes? BuscarPorIdentificacion(string id)      //busqueda por ID
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            return clientes.FirstOrDefault(c => c.ClienteIdentificacion == id);
        }
    }
}

