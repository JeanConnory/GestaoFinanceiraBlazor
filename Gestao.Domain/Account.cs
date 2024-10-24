namespace Gestao.Domain;

public class Account
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Balance { get; set; }
    public DateTimeOffset BalanceDate { get; set; }

    public int? CompanyId { get; set; }
    public Company Company { get; set; }

}
