
namespace PosTerminal.Net.Domain.Entities.Identities;

public class UserRefreshToken : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public UserRefreshToken()
    {
        CreatedAt = DateTime.Now;
    }

    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsValid { get; set; }
}