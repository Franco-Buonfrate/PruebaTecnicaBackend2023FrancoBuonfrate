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

        #region Validaciones nombre
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo nombre solo puede contener letras y espacios")]
        #endregion
        public string Nombre { get; set; } = null!;

        #region Validaciones Apellido
        [MaxLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El campo apellido solo puede contener letras y espacios")]
        #endregion
        public string Apellido { get; set; } = null!;

        #region Validaciones fechaNacimiento
        [DefaultValue("2002-07-22")]
        #endregion
        public DateTime FechaNacimiento { get; set; }

        #region Validaciones direccion
        [MaxLength(250, ErrorMessage = "La direccion no puede superar los 250 caracteres")]
        [RegularExpression(@"^[a-zA-Z0-9\s\.,#-]+$", ErrorMessage = "El campo dirección contiene caracteres no válidos")]
        #endregion
        public string? Direccion { get; set; }

        public long? Telefono { get; set; }

        #region Validaciones email
        [MaxLength(200, ErrorMessage = "El email no puede superar los 200 caracteres")]
        [EmailAddress(ErrorMessage = "El formato de correo es incorrecto")]
        #endregion
        public string? Email { get; set; }

        #region Validaciones dni
        [DniValidation]
        [Range(10000000, 99999999, ErrorMessage = "El DNI debe tener exactamente 8 caracteres")]
        [DefaultValue(59036076)]
        #endregion
        public long Dni { get; set; }

        #region Validaciones cuit
        [CuilValidation]
        [Range(10000000000, 99999999999, ErrorMessage = "El cuil debe tener exactamente 11 caracteres")]
        [DefaultValue(30590360763)]
        #endregion
        public long? Cuit { get; set; }
    }
}
