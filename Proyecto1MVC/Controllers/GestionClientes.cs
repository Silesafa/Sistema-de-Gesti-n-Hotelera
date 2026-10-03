using Microsoft.AspNetCore.Mvc;
using Proyecto1MVC.Models;
using Proyecto1MVC.Services;
using System.Text.RegularExpressions;

namespace Proyecto1MVC.Controllers

{
    public class ClientesController : Controller
    {
        private readonly IClienteServices _clienteService;   //se usa solo dentro de la clase cliente y de lectura para no poder cambiar y afectar la referencia (clienteservice)

        public ClientesController(IClienteServices clienteService)
        {
            _clienteService = clienteService;
        }

        // INDEX
        public IActionResult Index()
        {
            return View(_clienteService.GetAll());
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View(new GestionClientes
            {
                FechaNacimiento = DateTime.Today  //para que en datechooser aparezca con fecha de hoy
            });
        }


        // CREATE - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GestionClientes cliente)
        {
            // Validación de # de cedula,Dimex o Pasaporte
            if (cliente.TipoIdentificacion == "Cedula" &&
                !Regex.IsMatch(cliente.ClienteIdentificacion, @"^\d{1}-\d{4}-\d{4}$"))
                ModelState.AddModelError("ClienteIdentificacion", "Formato de cédula inválido.");

            else if (cliente.TipoIdentificacion == "DIMEX" &&
                !Regex.IsMatch(cliente.ClienteIdentificacion, @"^\d{12}$"))
                ModelState.AddModelError("ClienteIdentificacion", "DIMEX debe tener exactamente 12 dígitos.");

            else if (cliente.TipoIdentificacion == "Pasaporte" &&
                !Regex.IsMatch(cliente.ClienteIdentificacion, @"^[a-zA-Z0-9]{1,50}$"))
                ModelState.AddModelError("ClienteIdentificacion", "Pasaporte debe ser alfanumérico (1-50 caracteres).");

            if (ModelState.IsValid)
            {
                _clienteService.Add(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // EDIT - GET
        public IActionResult Edit(string id)
        {
            var cliente = _clienteService.GetById(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // EDIT - POST
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(string id, GestionClientes clienteActualizado)
        {
            // Validación según el tipo de ID seleccionado 
            switch (clienteActualizado.TipoIdentificacion)
            {
                case "Cedula":
                    if (!Regex.IsMatch(clienteActualizado.ClienteIdentificacion, @"^\d{1}-\d{4}-\d{4}$"))
                        ModelState.AddModelError("ClienteIdentificacion", "Formato de cédula inválido (ej: 1-1111-0909).");
                    break;

                case "DIMEX":
                    if (!Regex.IsMatch(clienteActualizado.ClienteIdentificacion, @"^\d{12}$"))
                        ModelState.AddModelError("ClienteIdentificacion", "DIMEX debe tener exactamente 12 dígitos.");
                    break;

                case "Pasaporte":
                    if (!Regex.IsMatch(clienteActualizado.ClienteIdentificacion, @"^[a-zA-Z0-9]{1,50}$"))
                        ModelState.AddModelError("ClienteIdentificacion", "Pasaporte debe ser alfanumérico (1-50 caracteres).");
                    break;
            }

            if (ModelState.IsValid)
            {
                _clienteService.Update(id, clienteActualizado);
                return RedirectToAction(nameof(Index));
            }

            return View(clienteActualizado);
        }



        // DELETE - GET
        public IActionResult Delete(string id)
        {
            var cliente = _clienteService.GetById(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            _clienteService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // DETAILS
        public IActionResult Details(string id)
        {
            var cliente = _clienteService.GetById(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }
        //search get
        [HttpGet]
        public IActionResult Search()
        {
            // redirige a vista Search
            return View(new List<GestionClientes>());
        }

        //Buscar por ID
        [HttpGet]
        public IActionResult BuscarPorIdentificacion(string identificacion)
        {
            var resultado = _clienteService.BuscarPorIdentificacion(identificacion);
            if (resultado == null)
            {
                ViewBag.Mensaje = "No se encontró ningún cliente con esa identificación.";
                return View("Search", new List<GestionClientes>());
            }
            return View("Search", new List<GestionClientes> { resultado });
        }
    }
}

