using Microsoft.AspNetCore.Identity;

namespace PosTerminal.Net.Domain.Entities.Identities;

public class Role : IdentityRole<int>
{
    public Role()
    {
        CreatedDate = DateTime.Now;
    }

    public string DisplayName { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<RoleClaim> Claims { get; set; } = new List<RoleClaim>();
    public ICollection<UserRole> Users { get; set; } = new HashSet<UserRole>();


}