using Gestao.Domain.Enums;
using Gestao.Domain.Interfaces;
using Gestao.Domain.Libraries.Validations;
using System.ComponentModel.DataAnnotations;

namespace Gestao.Domain;

public class FinancialTransaction : ISoftDelete
{
    public int Id { get; set; }
    public TypeFinancialTransaction TypeFinancialTransaction { get; set; }

    [Required(ErrorMessage = "O campo 'Descrição' é obrigatório!")]
    [MinLength(3, ErrorMessage = "O campo 'Descrição' deve ter pelo menos {1} caracteres")]
    public string Description { get; set; }

    [Range(typeof(DateTimeOffset), "1/1/2000", "1/1/2300", ErrorMessage = "A data deve estar entre {1:dd/MM/yyyy} e {2:dd/MM/yyyy}")]
    [Required(ErrorMessage = "O campo 'Data competência' é obrigatório!")]
    public DateTimeOffset ReferenceDate { get; set; }

    [Range(typeof(DateTimeOffset), "1/1/2000", "1/1/2300", ErrorMessage = "A data deve estar entre {1:dd/MM/yyyy} e {2:dd/MM/yyyy}")]
    [RequiredIfAmountPaidFilled]
    public DateTimeOffset? DueDate { get; set; }

    [Range(0.1, 10000000000, ErrorMessage = "O campo 'Valor' deve ter entre {1} e {2}")]
    [RequiredIfAmountPaidFilled]
    public decimal? Amount { get; set; }

    public Recurrence Repeat { get; set; }

    [Range(1, 10000, ErrorMessage = "O campo 'Repetir' deve ter entre {1} e {2}")]
    [RequiredRepeatTimes]
    public int? RepeatTimes { get; set; }

    [Range(0, 10000000000, ErrorMessage = "O campo 'Valor' deve ter entre {1} e {2}")]
    public decimal? InterestPenalty { get; set; }

    [DiscountNotBeGreaterThanAmount]
    [Range(0, 10000000000, ErrorMessage = "O campo 'Valor' deve ter entre {1} e {2}")]
    public decimal? Discounts { get; set; }

    [Range(typeof(DateTimeOffset), "1/1/2000", "1/1/2300", ErrorMessage = "A data deve estar entre {1:dd/MM/yyyy} e {2:dd/MM/yyyy}")]
    [RequiredIfAmountPaidFilled]
    public DateTimeOffset? PaymentDate { get; set; }

    [Range(0.1, 10000000000, ErrorMessage = "O campo 'Valor' deve ter entre {1} e {2}")]
    [AmountPaidValue]
    public decimal? AmountPay { get; set; }
    
    public string Observation { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? DeleteAt { get; set; }

    public ICollection<Document> Documents { get; set; }

    public int? CompanyId { get; set; }
    public Company Company { get; set; }

    [RequiredIfAmountPaidFilled]
    public int? AccountId { get; set; }
    public Account Account { get; set; }

    [RequiredIfAmountPaidFilled]
    public int? CategoryId { get; set; }
    public Category Category { get; set; }    
}
