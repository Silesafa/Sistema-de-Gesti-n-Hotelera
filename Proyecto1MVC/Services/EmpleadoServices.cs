using Proyecto1MVC.Models;

namespace Proyecto1MVC.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private static List<GestionEmpleados> empleados = new List<GestionEmpleados>();

        public IEnumerable<GestionEmpleados> GetAll() => empleados;

        public GestionEmpleados? GetById(string id) =>
            empleados.FirstOrDefault(e => e.EmpleadoIdentificacion == id);

        public void Add(GestionEmpleados empleado) => empleados.Add(empleado);

        public void Update(string id, GestionEmpleados empleadoActualizado)
        {
            var existente = GetById(id);
            if (existente != null)
            {
                existente.Nombre = empleadoActualizado.Nombre;
                existente.PrimerApellido = empleadoActualizado.PrimerApellido;
                existente.SegundoApellido = empleadoActualizado.SegundoApellido;
                existente.FechaNacimiento = empleadoActualizado.FechaNacimiento;
                existente.FechaIngreso = empleadoActualizado.FechaIngreso;
                existente.Categoria = empleadoActualizado.Categoria;
                existente.Salario = empleadoActualizado.Salario;
                existente.Provincia = empleadoActualizado.Provincia;
                existente.Canton = empleadoActualizado.Canton;
                existente.Distrito = empleadoActualizado.Distrito;
                existente.DireccionExacta = empleadoActualizado.DireccionExacta;
                existente.TipoIdentificacion = empleadoActualizado.TipoIdentificacion;
                existente.EmpleadoIdentificacion = empleadoActualizado.EmpleadoIdentificacion;
            }
        }



        public void Delete(string id)
        {
            var existente = GetById(id);
            if (existente != null)
                empleados.Remove(existente);
        }

        public GestionEmpleados? BuscarPorIdentificacion(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            return empleados.FirstOrDefault(e => e.EmpleadoIdentificacion == id);
        }
    }
}

