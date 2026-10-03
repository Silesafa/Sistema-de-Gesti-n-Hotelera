using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1MVC.Models;
using Proyecto1MVC.Services;

namespace Proyecto1MVC.Controllers

{
    public class ReservacionesController : Controller
    {
        private readonly IReservacionServices _reservacionService;

        public ReservacionesController(IReservacionServices reservacionService)
        {
            _reservacionService = reservacionService;
        }

        // INDEX
        public IActionResult Index() => View(_reservacionService.GetAll());

        // DETAILS
        public IActionResult Details(string codigo)
        {
            var reservacion = _reservacionService.GetByCodigo(codigo);
            if (reservacion == null) return NotFound();
            return View(reservacion);
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.EstadosReservacion = new SelectList(
                new List<string> { "Reservada", "Confirmada", "Cancelada", "Completada" }
            );

            return View(new GestionReservaciones
            {
                FechaIngreso = DateTime.Today,
                FechaSalida = DateTime.Today.AddDays(1),
                CantidadPersonas = 1,
                EstadoReservacion = "Reservada"
            });
        }


        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GestionReservaciones reservacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _reservacionService.Add(reservacion);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("NumeroHabitacion", ex.Message);
                }
            }
            return View(reservacion);
        }


        // EDIT - GET
        public IActionResult Edit(string codigo)
        {
            var reservacion = _reservacionService.GetByCodigo(codigo);
            if (reservacion == null) return NotFound();

            ViewBag.EstadosReservacion = new SelectList(
                new List<string> { "Reservada", "Confirmada", "Cancelada", "Completada" },
                reservacion.EstadoReservacion
            );

            return View(reservacion);
        }


        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(GestionReservaciones reservacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _reservacionService.Update(reservacion.CodigoReservacion, reservacion);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // Si hay error, vuelve a cargar el select de estados
            ViewBag.EstadosReservacion = new SelectList(
                new List<string> { "Reservada", "Confirmada", "Cancelada", "Completada" },
                reservacion.EstadoReservacion
            );

            return View(reservacion);
        }


        // DELETE - GET
        public IActionResult Delete(string codigo)
        {
            var reservacion = _reservacionService.GetByCodigo(codigo);
            if (reservacion == null) return NotFound();
            return View(reservacion);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(GestionReservaciones reservacion)
        {
            _reservacionService.Delete(reservacion.CodigoReservacion);
            return RedirectToAction(nameof(Index));
        }


        // SEARCH - GET
        [HttpGet]
        public IActionResult Search()
        {
            // Renderiza la vista Search.cshtml sin resultados iniciales
            return View(new List<GestionReservaciones>());
        }


        //Busqueda por codigo o cliente
        [HttpGet]
        public IActionResult BuscarPorCodigo(string codigo)
        {
            var resultado = _reservacionService.BuscarPorCodigo(codigo);
            if (resultado == null)
            {
                ViewBag.Mensaje = "No se encontró ninguna reservación con ese código.";
                return View("Search", new List<GestionReservaciones>());
            }
            return View("Search", new List<GestionReservaciones> { resultado });
        }

        [HttpGet]
        public IActionResult BuscarPorCliente(string clienteId)
        {
            var resultado = _reservacionService.BuscarPorCliente(clienteId);
            if (resultado == null)
            {
                ViewBag.Mensaje = "No se encontró ninguna reservación para ese cliente.";
                return View("Search", new List<GestionReservaciones>());
            }
            return View("Search", new List<GestionReservaciones> { resultado });

        }



    }
}
