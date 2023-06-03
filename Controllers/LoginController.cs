using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;
using PruebaTecnicaBackend2023FrancoBuonfrate.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        private IConfiguration config;

        public LoginController(LoginService loginService, IConfiguration config)
        {
            _loginService = loginService;
            this.config = config;
        }

        [HttpPost("autenticacion")]
        public async Task<IActionResult> Login (UsuarioAcceso usuario)
        {
            var acceso = await _loginService.GetAdmin(usuario);

            if (acceso is null)
                return BadRequest(new
                {
                    message = "Credenciales invalidas"
                });

            string token = GenerateToken(acceso);

            return Ok(new
            {
                token = token
            });
        }

        private string GenerateToken(UsuarioAcceso usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Usuario),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt:Key").Value));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }
    }
}
