using System.ComponentModel.DataAnnotations;

namespace Movimientos.API.Models.CustomValidation;

public class NotZeroAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        decimal dt = (decimal)value;
        if (dt != 0)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult(ErrorMessage ?? "Valor no puede ser igual a 0.");
    }
}