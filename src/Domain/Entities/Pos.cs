using PosTerminal.Net.Domain.Entities.Identities;

namespace PosTerminal.Net.Domain.Entities;
public class Pos
{
    public int Id { get; set; }
    public int TerminalId { get; set; }
    public Bank Bank { get; set; }
    public bool IsActive { get; set; }
    public string? Description { get; set; }
    public ICollection<User> Users { get; } = new List<User>();
    public ICollection<PosTransaction> PosTransactions { get; set; }
                        = new List<PosTransaction>();
}
