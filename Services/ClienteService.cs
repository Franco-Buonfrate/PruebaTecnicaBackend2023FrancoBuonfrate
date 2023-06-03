using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Services
{
    public class ClienteService
    {
        private readonly ClientesContext _context;

        public ClienteService(ClientesContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetList()
        {
            return _context.Clientes.ToList();
        }

        public Cliente? GetByDni(long dni)
        {
            return _context.Clientes.FirstOrDefault(cli => cli.Dni == dni);

        }

    }
}
