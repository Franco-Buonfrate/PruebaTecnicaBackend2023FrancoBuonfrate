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

        /// <summary>
        /// Obtiene una lista de todos los clientes.
        /// </summary>
        /// <returns>Una lista de objetos Cliente.</returns>
        [HttpGet("listar")]
        public async Task<IEnumerable<Cliente>> GetList()
        {
            return await _service.GetList();
        }

        /// <summary>
        /// Obtiene los detalles de un cliente específico por su DNI.
        /// </summary>
        /// <param name="dni">DNI del cliente.</param>
        /// <returns>Un objeto Cliente.</returns>
        /// <response code="200">La instancia del cliente con el DNI especificado</response>
        /// <response code="404">El cliente con DNI = X no se ha encontrado</response>
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

        /// <summary>
        /// Crea un nuevo cliente.
        /// </summary>
        /// <param name="cliente">Objeto Cliente que representa al nuevo cliente.</param>
        /// <returns>Respuesta HTTP que indica el éxito de la operación y los detalles del nuevo cliente.</returns>
        /// <response code="201">Cliente creado correctamente.</response>
        [HttpPost("agregar")]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            var newCliente = await _service.Create(cliente);

            return CreatedAtAction(nameof(GetByDni), new { dni = newCliente.Dni }, newCliente);
        }


    }
}
