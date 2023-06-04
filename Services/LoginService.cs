using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Services
{
    public class LoginService
    {
        private readonly Context _context;

        public LoginService(Context context)
        {
            _context = context;
        }

        public async Task<UsuarioAcceso?> GetAdmin(UsuarioAcceso usuario)
        {
            return await _context.UsuarioAccesos.SingleOrDefaultAsync(
                user => user.Usuario == usuario.Usuario && user.Password == usuario.Password);
        }

    }
}
