using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Validations
{
    public class CuilValidationAttribute : ValidationAttribute
    {
        private static readonly long[] multiplicador = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

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
