namespace PosTerminal.Net.Domain.Entities;
public class Pos : BaseEntity
{
    public int TerminalId { get; init; }
    public Bank Bank{ get; init; }
    public bool IsActive { get; init; }

}
