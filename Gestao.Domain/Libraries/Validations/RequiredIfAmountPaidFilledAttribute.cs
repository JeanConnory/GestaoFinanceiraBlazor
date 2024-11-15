using System.ComponentModel.DataAnnotations;

namespace Gestao.Domain.Libraries.Validations;

public class RequiredIfAmountPaidFilledAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        FinancialTransaction transaction = (FinancialTransaction)validationContext.ObjectInstance;

        if (transaction.AmountPay.HasValue)
        {
            if (value is null)
                return new ValidationResult("O campo é obrigatório!", new[] { validationContext.MemberName! });
        }

        return ValidationResult.Success;
    }
}
