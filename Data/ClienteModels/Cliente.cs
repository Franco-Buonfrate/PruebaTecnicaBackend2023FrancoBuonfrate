using PruebaTecnicaBackend2023FrancoBuonfrate.Services;
using PruebaTecnicaBackend2023FrancoBuonfrate.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels
{
    public partial class Cliente
    {
        [JsonIgnore]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 carateres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo nombre solo puede contener letras y espacios")]
        public string Nombre { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "El apellido no puede superar los 100 carateres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo apellido solo puede contener letras y espacios")]
        public string Apellido { get; set; } = null!;

        //[DataType(DataType.Date)]
        //[RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "El formato de fecha debe ser yyyy-MM-dd")]
        [DefaultValue("2002-07-22")]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(250, ErrorMessage = "La direccion no puede superar los 250 carateres")]
        [RegularExpression(@"^[a-zA-Z0-9\s\.,#-]+$", ErrorMessage = "El campo dirección contiene caracteres no válidos")]
        public string? Direccion { get; set; }

        public long? Telefono { get; set; }

        [MaxLength(200, ErrorMessage = "El email no puede superar los 200 carateres")]
        [EmailAddress(ErrorMessage = "El formato de correo es incorrecto")]
        public string? Email { get; set; }

        [DniValidation]
        [Range(10000000, 99999999, ErrorMessage = "El DNI debe tener exactamente 8 caracteres")]
        [DefaultValue(59036076)]
        public long Dni { get; set; }

        [CuilValidation]
        [Range(10000000000, 99999999999, ErrorMessage = "El cuil debe tener exactamente 11 caracteres")]
        [DefaultValue(30590360763)]
        public long? Cuit { get; set; }
    }
}
