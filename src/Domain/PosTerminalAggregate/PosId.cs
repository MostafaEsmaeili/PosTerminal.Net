
namespace PosTerminal.Net.Domain.PosTerminalAggregate;

public sealed class PosId : ValueObject
{
    public Guid Id { get; }
    private PosId(Guid id)
    {
        Id = id;
    }
    public static PosId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}