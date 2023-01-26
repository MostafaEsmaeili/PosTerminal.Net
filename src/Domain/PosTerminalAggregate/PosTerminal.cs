using PosTerminal.Net.Domain.Entities.Identities;

namespace PosTerminal.Net.Domain.PosTerminalAggregate;
public class Pos : BaseEntity<PosId>
{
    private Pos(PosId id, int terminalId, Bank bank, bool isActive)
        : base(id)
    {
        TerminalId = terminalId;
        Bank = bank;
        IsActive = isActive;
    }
    public static Pos CreateNew(int terminalId, Bank bank)
    {
        return new(
            id: PosId.CreateUnique(),
            terminalId: terminalId,
            bank: bank,
            isActive: true);
    }
    public int TerminalId { get; }
    public Bank Bank { get; }
    public bool IsActive { get; set; }
    public void Deactivate()
    {
        IsActive = false;
    }
    public void Active()
    {
        IsActive = true;
    }


    public ICollection<User> Users { get; } = new HashSet<User>();

}
