using Microsoft.AspNetCore.Identity;

namespace PosTerminal.Net.Domain.Entities.Identities;

public class UserLogin : IdentityUserLogin<int>
{
    public UserLogin()
    {
        LoggedOn = DateTime.Now;
    }

    public User User { get; set; }
    public DateTime LoggedOn { get; set; }
}