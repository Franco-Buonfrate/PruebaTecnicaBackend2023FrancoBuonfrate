using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels
{
    public partial class Cliente
    {
        [JsonIgnore]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 carateres")]
        public string Nombre { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "El apellido no puede superar los 100 carateres")]
        public string Apellido { get; set; } = null!;

        public DateTime FechaNacimiento { get; set; }

        [MaxLength(250, ErrorMessage = "La direccion no puede superar los 250 carateres")]
        public string? Direccion { get; set; }

        [Phone(ErrorMessage = "El formato de telefono no es correcto")]
        public long? Telefono { get; set; }

        [MaxLength(200, ErrorMessage = "El email no puede superar los 200 carateres")]
        [EmailAddress(ErrorMessage = "El formato de correo es incorrecto")]
        public string? Email { get; set; }

        [MaxLength(8, ErrorMessage = "El DNI no puede superar los 8 caracteres")]
        public long Dni { get; set; }

        public long? Cuit { get; set; }
    }
}
