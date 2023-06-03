using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;
using PruebaTecnicaBackend2023FrancoBuonfrate.Services;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetList()
        {
            return _service.GetList();
        }

        [HttpGet("{dni}")]
        public ActionResult<Cliente> GetByDni(long dni)
        {
            var cliente = _service.GetByDni(dni);
            if(cliente is null)
                return NotFound();
            return Ok(cliente);
        }

    }
}
