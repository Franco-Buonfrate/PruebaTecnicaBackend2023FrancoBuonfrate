using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Validations
{
    public class CuilValidationAttribute : ValidationAttribute
    {
        private static readonly long[] multiplicador = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

        /// <summary>
        /// Valida si el valor del CUIL proporcionado en el objeto de validación es válido.
        /// </summary>
        /// <param name="value">El valor del CUIL a validar.</param>
        /// <param name="validationContext">El contexto de validación que contiene la instancia del objeto a validar.</param>
        /// <returns>
        /// Un objeto ValidationResult que representa el resultado de la validación.
        /// Si la validación es exitosa, ValidationResult.Success; de lo contrario, una instancia de ValidationResult con un mensaje de error.
        /// </returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            long cuil = (validationContext.ObjectInstance as Cliente)?.Cuit ?? 0;
            long sumador = 0;

            for (int i = 0; i < 10; i++)
            {
                var num = (long)((cuil) / Math.Pow(10, 10-i)) % 10;
                sumador += multiplicador[i] * num;
            }

            var resto = 11 - (sumador % 11);
            var digitoVerificador = (long)((cuil) / Math.Pow(10, 0)) % 10;

            if ( resto != digitoVerificador)
            {
                return new ValidationResult($"El CUIL no es válido." );
            }

            return ValidationResult.Success;
        }
    }
}
