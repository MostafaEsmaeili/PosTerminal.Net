using PosTerminal.Net.Domain.Entities.Identities;

namespace PosTerminal.Net.Domain.Entities;
public class UserPos : BaseEntity
{
    private UserPos()
    {

    }
    public Pos Pos { get; init; }
    public User User { get; init; }
}
