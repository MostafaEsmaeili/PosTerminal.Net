
using PosTerminal.Net.Domain.Entities.Identities;
namespace PosTerminal.Net.Domain.Entities;
public class PosTransaction
{
    public int Id { get; set; }
    public DateTimeOffset TransactionDate { get; set; }

    public int PosId { get; set; }
    public int UserId { get; set; }
    public PosTransactionStatus Status { get; set; }
    public Pos Pos { get; set; } = null!;
    public User User { get; set; } = null!;

}