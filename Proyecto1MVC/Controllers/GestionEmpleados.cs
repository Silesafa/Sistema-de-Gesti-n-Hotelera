using Microsoft.AspNetCore.Mvc;
using Proyecto1MVC.Models;
using Proyecto1MVC.Services;
using System.Text.RegularExpressions;

namespace Proyecto1MVC.Controllers

{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // INDEX
        public IActionResult Index()
        {
            return View(_empleadoService.GetAll());
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View(new GestionEmpleados
            {
                FechaNacimiento = DateTime.Today,
                FechaIngreso = DateTime.Today
            });
        }


        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GestionEmpleados empleado)
        {
            if (ModelState.IsValid)
            {
                _empleadoService.Add(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // EDIT - GET
        public IActionResult Edit(string id)
        {
            var empleado = _empleadoService.GetById(id);
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        // EDIT - POST
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(string id, GestionEmpleados empleadoActualizado)
        {
            switch (empleadoActualizado.TipoIdentificacion)
            {
                case "Cedula":
                    if (!Regex.IsMatch(empleadoActualizado.EmpleadoIdentificacion, @"^\d{1}-\d{4}-\d{4}$"))
                        ModelState.AddModelError("EmpleadoIdentificacion", "Formato de cédula inválido (ej: 1-1111-0909).");
                    break;

                case "DIMEX":
                    if (!Regex.IsMatch(empleadoActualizado.EmpleadoIdentificacion, @"^\d{12}$"))
                        ModelState.AddModelError("EmpleadoIdentificacion", "DIMEX debe tener exactamente 12 dígitos.");
                    break;

                case "Pasaporte":
                    if (!Regex.IsMatch(empleadoActualizado.EmpleadoIdentificacion, @"^[a-zA-Z0-9]{1,50}$"))
                        ModelState.AddModelError("EmpleadoIdentificacion", "Pasaporte debe ser alfanumérico (1-50 caracteres).");
                    break;
            }

            if (ModelState.IsValid)
            {
                _empleadoService.Update(id, empleadoActualizado);
                return RedirectToAction(nameof(Index));
            }

            return View(empleadoActualizado);
        }


        // DELETE - GET
        public IActionResult Delete(string id)
        {
            var empleado = _empleadoService.GetById(id);
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _empleadoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        public IActionResult Details(string id)
        {
            var empleado = _empleadoService.GetById(id);
            if (empleado == null) return NotFound();
            return View(empleado);
        }

        //Search get
        [HttpGet]
        public IActionResult Search()
        {
            return View(new List<GestionEmpleados>());
        }

        //Buscar por ID Empleado
        [HttpGet]
        public IActionResult BuscarPorIdentificacion(string id)
        {
            var resultado = _empleadoService.BuscarPorIdentificacion(id);
            if (resultado == null)
            {
                ViewBag.Mensaje = "No se encontró ningún empleado con esa identificación.";
                return View("Search", new List<GestionEmpleados>());
            }
            return View("Search", new List<GestionEmpleados> { resultado });
       }
    }
}