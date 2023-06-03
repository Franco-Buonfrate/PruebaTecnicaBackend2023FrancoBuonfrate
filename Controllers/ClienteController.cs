using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly ClientesContext _context;

        public ClienteController(ClientesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetList()
        {
            return _context.Clientes.ToList();
        }

        [HttpGet("{dni}")]
        public ActionResult<Cliente> GetByDni(long dni)
        {
            var cliente = _context.Clientes.FirstOrDefault(cli => cli.Dni == dni);
            if(cliente is null)
                return NotFound();
            return Ok(cliente);
        }
    }
}
