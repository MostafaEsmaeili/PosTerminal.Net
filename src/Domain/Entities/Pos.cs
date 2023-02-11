using PosTerminal.Net.Domain.Entities.Identities;
using System.Net.Http.Headers;

namespace PosTerminal.Net.Domain.Entities;
public class Pos : BaseEntity<int>
{
    private Pos()
    {
    }
    public Pos(int terminalId, Bank bank)
    {
        TerminalId = terminalId;
        Bank = bank;
        Id = 0;
        IsActive = true;
    }
    public int TerminalId { get; set; }
    public Bank Bank { get; set; }
    public bool IsActive { get; set; }
    public string? Description { get; set; }
    public int? UserId { get; set; }
    public User User { get; } = null!;
    public ICollection<PosTransaction> PosTransactions { get; set; }
                        = new List<PosTransaction>();
}
