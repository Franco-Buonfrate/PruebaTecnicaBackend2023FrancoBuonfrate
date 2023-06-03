using System;
using System.Collections.Generic;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels
{
    public partial class UsuarioAcceso
    {
        public short Id { get; set; }
        public string Usuario { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
