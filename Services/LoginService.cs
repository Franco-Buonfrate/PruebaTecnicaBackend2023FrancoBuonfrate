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

        /// <summary>
        /// Obtiene un usuario con privilegios de administrador basado en las credenciales proporcionadas.
        /// </summary>
        /// <param name="usuario">Las credenciales del usuario que incluyen el nombre de usuario y la contraseña.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene el usuario con privilegios de administrador encontrado o null si no se encontró.</returns>
        public async Task<UsuarioAcceso?> GetAdmin(UsuarioAcceso usuario)
        {
            return await _context.UsuarioAccesos.SingleOrDefaultAsync(
                user => user.Usuario == usuario.Usuario && user.Password == usuario.Password);
        }

    }
}
