using Microsoft.AspNetCore.Mvc;
using Proyecto1MVC.Models;
using Proyecto1MVC.Services;

namespace Proyecto2API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesAPI : ControllerBase
    {
        private readonly IClienteServices _clienteService;

        public ClientesAPI(IClienteServices clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public ActionResult<GestionClientes> GetById(string id)
        {
            var cliente = _clienteService.GetById(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }
    }
}


