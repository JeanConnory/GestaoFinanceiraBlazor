using System.ComponentModel.DataAnnotations;

namespace Gestao.Domain.Libraries.Validations;

public class AmountPaidValueAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
            return ValidationResult.Success;

        FinancialTransaction transaction = (FinancialTransaction)validationContext.ObjectInstance;

        decimal total = 0;

        if (transaction.Amount.HasValue)
        {
            total = transaction.Amount.Value;

            if (transaction.InterestPenalty.HasValue)
            {
                total += transaction.InterestPenalty.Value;
            }
            if (transaction.Discounts.HasValue)
            {
                total -= transaction.Discounts.Value;
            }
            if (total != transaction.AmountPay)
            {
                return new ValidationResult($"Valor incorreto, deveria ser: {total.ToString("C")}. Verifique os campos 'Valor', 'Juros/Multas' e 'Desconto'.", new[] { validationContext.MemberName! });
            }
        }

        return ValidationResult.Success;
    }
}
