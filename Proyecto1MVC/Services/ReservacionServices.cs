using Proyecto1MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto1MVC.Services

{
    public class ReservacionService : IReservacionServices
    {
        private readonly IHabitacionServices _habitacionService;
        private static List<GestionReservaciones> reservaciones = new List<GestionReservaciones>();

        // Constructor de 
        public ReservacionService(IHabitacionServices habitacionService)
        {
            _habitacionService = habitacionService;
        }

        public IEnumerable<GestionReservaciones> GetAll() => reservaciones;

        public GestionReservaciones? GetByCodigo(string codigo) =>
            reservaciones.FirstOrDefault(r => r.CodigoReservacion == codigo);

        public void Add(GestionReservaciones reservacion)
        {
            // Validar que la habitacion exista
            var habitacion = _habitacionService.GetByNumero(reservacion.NumeroHabitacion);
            if (habitacion == null)
                throw new InvalidOperationException("La habitación seleccionada no está registrada.");

            // Validar fechas de reservaciones
            bool traslape = reservaciones.Any(r =>
                r.NumeroHabitacion == reservacion.NumeroHabitacion &&
                !(reservacion.FechaSalida <= r.FechaIngreso || reservacion.FechaIngreso >= r.FechaSalida)
            );
            if (traslape)
                throw new InvalidOperationException("La habitación ya está reservada en el rango de fechas seleccionado.");

            // Validar duplicado de codigo
            if (reservaciones.Any(r => r.CodigoReservacion == reservacion.CodigoReservacion))
                throw new InvalidOperationException("Ese código de reservación ya está registrado.");

            reservaciones.Add(reservacion);
        }

        public void Update(string codigoOriginal, GestionReservaciones reservacionActualizada)
        {
            var existente = GetByCodigo(codigoOriginal);
            if (existente != null)
            {
                // Validar habitacion registrada
                var habitacion = _habitacionService.GetByNumero(reservacionActualizada.NumeroHabitacion);
                if (habitacion == null)
                    throw new InvalidOperationException("La habitación seleccionada no está registrada.");

                // Validar reservacion
                bool traslape = reservaciones.Any(r =>
                    r.CodigoReservacion != codigoOriginal &&
                    r.NumeroHabitacion == reservacionActualizada.NumeroHabitacion &&
                    !(reservacionActualizada.FechaSalida <= r.FechaIngreso || reservacionActualizada.FechaIngreso >= r.FechaSalida)
                );
                if (traslape)
                    throw new InvalidOperationException("La habitación ya está reservada en el rango de fechas seleccionado.");

                // Validar duplicado de código
                if (codigoOriginal != reservacionActualizada.CodigoReservacion &&
                    reservaciones.Any(r => r.CodigoReservacion == reservacionActualizada.CodigoReservacion))
                    throw new InvalidOperationException("Ese código de reservación ya está registrado.");

                // Actualizar datos
                existente.CodigoReservacion = reservacionActualizada.CodigoReservacion;
                existente.ClienteIdentificacion = reservacionActualizada.ClienteIdentificacion;
                existente.NumeroHabitacion = reservacionActualizada.NumeroHabitacion;
                existente.FechaIngreso = reservacionActualizada.FechaIngreso;
                existente.FechaSalida = reservacionActualizada.FechaSalida;
                existente.CantidadPersonas = reservacionActualizada.CantidadPersonas;
                existente.EstadoReservacion = reservacionActualizada.EstadoReservacion;
            }
        }

        public void Delete(string codigo)
        {
            var existente = GetByCodigo(codigo);
            if (existente != null)
            {
                reservaciones.Remove(existente);
            }
           
        }

        public GestionReservaciones? BuscarPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return null;
            return reservaciones.FirstOrDefault(r => r.CodigoReservacion == codigo);
        }

        public GestionReservaciones? BuscarPorCliente(string clienteId)
        {
            if (string.IsNullOrWhiteSpace(clienteId)) return null;
            return reservaciones.FirstOrDefault(r => r.ClienteIdentificacion == clienteId);
        }
    }
}
