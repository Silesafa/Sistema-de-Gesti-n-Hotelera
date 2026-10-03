using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto1MVC.Models;
using Proyecto1MVC.Services;
using System.Text.RegularExpressions;

namespace Proyecto1MVC.Controllers

{
    public class HabitacionesController : Controller
    {
        private readonly IHabitacionServices _habitacionService;

        public HabitacionesController(IHabitacionServices habitacionService)
        {
            _habitacionService = habitacionService;
        }

        // INDEX
        public IActionResult Index() => View(_habitacionService.GetAll());

        // DETAILS
        public IActionResult Details(int numero)
        {
            var habitacion = _habitacionService.GetByNumero(numero);
            if (habitacion == null) return NotFound();
            return View(habitacion);
        }

        // CREATE - GET
        public IActionResult Create()
        {
            ViewBag.TiposHabitacion = new SelectList(
                new List<string> { "Start Junior", "Start Vista al Mar", "Master Start" }
            );
            return View();
        }


        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GestionHabitaciones habitacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _habitacionService.Add(habitacion);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("NumeroHabitacion", ex.Message);
                }
            }

            ViewBag.TiposHabitacion = new SelectList(
                new List<string> { "Start Junior", "Start Vista al Mar", "Master Start" },
                habitacion.TipoHabitacion
            );

            return View(habitacion);
        }


        // EDIT - GET
        public IActionResult Edit(int numero)
        {
            var habitacion = _habitacionService.GetByNumero(numero);
            if (habitacion == null) return NotFound();

            ViewBag.TiposHabitacion = new SelectList(
                new List<string> { "Start Junior", "Start Vista al Mar", "Master Start" },
                habitacion.TipoHabitacion
            );

            return View(habitacion);
        }




        // EDIT - POST
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(int numeroOriginal, GestionHabitaciones habitacionActualizada)
        {
            if (!Regex.IsMatch(habitacionActualizada.TipoHabitacion, "^(Start Junior|Start Vista al Mar|Master Start)$"))
            {
                ModelState.AddModelError("TipoHabitacion", "El tipo de habitación debe ser: Start Junior, Start Vista al Mar o Master Start.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _habitacionService.Update(numeroOriginal, habitacionActualizada);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("NumeroHabitacion", ex.Message);
                }
            }

            ViewBag.TiposHabitacion = new SelectList(
                new List<string> { "Start Junior", "Start Vista al Mar", "Master Start" },
                habitacionActualizada.TipoHabitacion
            );

            return View(habitacionActualizada);
        }






        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int numero)
        {
            _habitacionService.Delete(numero);
            return RedirectToAction(nameof(Index));
        }
        //Search get
        [HttpGet]
        public IActionResult Search()
        {
            return View(new List<GestionHabitaciones>());
        }

        //Busqueda por numero de habitacion
        [HttpGet]
        public IActionResult BuscarPorNumeroHabitacion(int numero)
        {
            var resultado = _habitacionService.BuscarPorNumeroHabitacion(numero);
            if (resultado == null)
            {
                ViewBag.Mensaje = "No se encontró ninguna habitación con ese número.";
                return View("Search", new List<GestionHabitaciones>());
            }
            return View("Search", new List<GestionHabitaciones> { resultado });
        }

    }
}

