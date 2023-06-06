using PruebaTecnicaBackend2023FrancoBuonfrate.Data;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Validations
{
    public class DniValidationAttribute : ValidationAttribute
    {
        /// <summary>
        /// Valida si el valor del DNI proporcionado en el objeto de validación es válido.
        /// </summary>
        /// <param name="value">El valor del DNI a validar.</param>
        /// <param name="validationContext">El contexto de validación que contiene la instancia del objeto a validar.</param>
        /// <returns>
        /// Un objeto ValidationResult que representa el resultado de la validación.
        /// Si la validación es exitosa, ValidationResult.Success; de lo contrario, una instancia de ValidationResult con un mensaje de error.
        /// </returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is Cliente cliente)
            {
                var serviceProvider = validationContext.GetService<IServiceProvider>();
                if (serviceProvider != null)
                {
                    using var scope = serviceProvider.CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
                    var existeDni = dbContext.Clientes.FirstOrDefault(cli => cli.Dni == cliente.Dni);
                    if (existeDni != null)
                    {
                        return new ValidationResult("El dni ya está registrado");
                    }
                }
            }

            return ValidationResult.Success;
        }

    }
}
