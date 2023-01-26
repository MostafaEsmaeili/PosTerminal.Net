
namespace PosTerminal.Net.Domain.Entities.Identities;

public class UserRefreshToken : BaseEntity<Guid>
{
    private UserRefreshToken(Guid id,
                             int userId,
                             bool isValid) : base(id)
    {
        Id = id;
        CreatedAt = DateTime.Now;
    }
    public static UserRefreshToken CreateNew(int userId)
    {
        return new(Guid.NewGuid(), userId, true);
    }
    public int UserId { get; }
    public User User { get; } = null!;
    public DateTime CreatedAt { get; }
    public bool IsValid { get; }
}