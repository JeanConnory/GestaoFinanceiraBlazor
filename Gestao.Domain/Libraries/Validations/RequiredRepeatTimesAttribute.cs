using System.ComponentModel.DataAnnotations;

namespace Gestao.Domain.Libraries.Validations;

public class RequiredRepeatTimesAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        FinancialTransaction transaction = (FinancialTransaction)validationContext.ObjectInstance;

        if (transaction.Repeat != Enums.Recurrence.None)
        {
            if (value is null)
                return new ValidationResult("O campo 'Vezes' é obrigatório!", new[] { validationContext.MemberName! });
        }

        return ValidationResult.Success;
    }
}
