using Microsoft.AspNetCore.Identity;

namespace PosTerminal.Net.Domain.Entities.Identities;

public class RoleClaim : IdentityRoleClaim<int>
{
    public RoleClaim()
    {
        CreatedClaim = DateTime.Now;
    }

    public DateTime CreatedClaim { get; set; }
    public Role Role { get; set; }

}