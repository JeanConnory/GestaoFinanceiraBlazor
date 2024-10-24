using Gestao.Domain.Enums;

namespace Gestao.Domain;

public class FinancialTransaction
{
    public int Id { get; set; }
    public TypeFinancialTransaction TypeFinancialTransaction { get; set; }
    public string Description { get; set; }
    public DateTimeOffset ReferenceDate { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public decimal Amount { get; set; }
    public decimal InterestPenalty { get; set; }
    public decimal Discounts { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public decimal AmountPay { get; set; }
    public string Observation { get; set; }
    public DateTimeOffset CreatedAt { get; set; }


    public ICollection<Document> Documents { get; set; }

    public Recurrence Repeat { get; set; }
    public int RepeatTimes { get; set; }

    public int? CompanyId { get; set; }
    public Company Company { get; set; }

    public int? AccountId { get; set; }
    public Account Account { get; set; }

    public int? CategoryId { get; set; }
    public Category Category { get; set; }
}
