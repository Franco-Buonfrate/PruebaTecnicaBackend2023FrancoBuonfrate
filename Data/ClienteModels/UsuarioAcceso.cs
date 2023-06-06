using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels
{
    public partial class UsuarioAcceso
    {
        [JsonIgnore]
        public short Id { get; set; }

        [MaxLength(10, ErrorMessage = "El usuario no debe superar los 10 caracteres")]
        public string Usuario { get; set; } = null!;

        [MaxLength(10, ErrorMessage = "La contraseña no debe superar los 10 caracteres")]
        public string Password { get; set; } = null!;
    }
}
