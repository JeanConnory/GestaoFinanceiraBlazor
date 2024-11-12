namespace Gestao.Domain.Interfaces;

public interface ISoftDelete
{
    DateTimeOffset? DeleteAt { get; set; }
}
