using Microsoft.AspNetCore.Identity;

namespace PosTerminal.Net.Domain.Entities.Identities;

public class UserRole : IdentityUserRole<int>
{
    public User User { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedUserRoleDate { get; set; }

}