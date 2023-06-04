using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Services
{
    public class ClienteService
    {
        private readonly Context _context;

        public ClienteService(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetList()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByDni(long dni)
        {
            return await _context.Clientes.FirstOrDefaultAsync(cli => cli.Dni == dni);

        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }
    }
}
