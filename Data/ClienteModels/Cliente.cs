using System;
using System.Collections.Generic;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public long? Telefono { get; set; }
        public string? Email { get; set; }
        public long Dni { get; set; }
        public long? Cuit { get; set; }
    }
}
