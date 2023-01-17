using Microsoft.AspNetCore.Identity;

namespace PosTerminal.Net.Domain.Entities.Identities;

public class UserToken : IdentityUserToken<int>
{
    public UserToken()
    {
        GeneratedTime = DateTime.Now;
    }

    public User User { get; set; }
    public DateTime GeneratedTime { get; set; }

}