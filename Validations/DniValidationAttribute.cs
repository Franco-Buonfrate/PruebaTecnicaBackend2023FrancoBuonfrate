using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data;
using PruebaTecnicaBackend2023FrancoBuonfrate.Data.ClienteModels;
using PruebaTecnicaBackend2023FrancoBuonfrate.Services;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaBackend2023FrancoBuonfrate.Validations
{
    public class DniValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is Cliente cliente)
            {
                var serviceProvider = validationContext.GetService<IServiceProvider>();
                if (serviceProvider != null)
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
                        var existeDni = dbContext.Clientes.FirstOrDefault(cli => cli.Dni == cliente.Dni);
                        if (existeDni != null)
                        {
                            return new ValidationResult("El dni ya está registrado");
                        }
                    }
                }
            }

            return ValidationResult.Success;
        }

    }
}
