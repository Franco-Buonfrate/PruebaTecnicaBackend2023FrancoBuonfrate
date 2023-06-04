using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;
using PruebaTecnicaBackend2023FrancoBuonfrate.Services;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<Cliente>> GetList()
        {
            return await _service.GetList();
        }

        [HttpGet("listarPorDni/{dni}")]
        public async Task<ActionResult<Cliente>> GetByDni(long dni)
        {
            var cliente = await _service.GetByDni(dni);
            if (cliente is null)
                return NotFound(new
                {
                    message = $"El cliente con DNI = {dni} no se ha encontrado"
                });
            return cliente;
        }

        [HttpPost("agregar")]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            var newCliente = await _service.Create(cliente);

            return CreatedAtAction(nameof(GetByDni), new { dni = newCliente.Dni }, newCliente);
        }


    }
}
