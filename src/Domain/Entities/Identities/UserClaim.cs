using Microsoft.AspNetCore.Identity;

namespace PosTerminal.Net.Domain.Entities.Identities;

public class UserClaim : IdentityUserClaim<int>
{
    public User User { get; set; }
}