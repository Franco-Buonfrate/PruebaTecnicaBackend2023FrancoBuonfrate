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

        /// <summary>
        /// Obtiene una lista de clientes.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene la lista de clientes.</returns>
        public async Task<IEnumerable<Cliente>> GetList()
        {
            return await _context.Clientes.ToListAsync();
        }

        /// <summary>
        /// Obtiene un cliente por su número de DNI.
        /// </summary>
        /// <param name="dni">El número de DNI del cliente.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene el cliente encontrado o null si no se encontró.</returns>
        public async Task<Cliente?> GetByDni(long dni)
        {
            return await _context.Clientes.FirstOrDefaultAsync(cli => cli.Dni == dni);

        }

        /// <summary>
        /// Crea un nuevo cliente.
        /// </summary>
        /// <param name="cliente">El objeto cliente a crear.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene el cliente creado.</returns>
        public async Task<Cliente> Create(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

    }
}
