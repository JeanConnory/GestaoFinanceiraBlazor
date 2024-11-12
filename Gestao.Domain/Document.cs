using Gestao.Domain.Interfaces;

namespace Gestao.Domain;

public class Document : ISoftDelete
{
    public int Id { get; set; }
    public string Path { get; set; } = null!;

    public int? FinancialTransactionId { get; set; }
    public FinancialTransaction FinancialTransaction { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset? DeleteAt { get; set; }
}
