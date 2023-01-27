using Microsoft.AspNetCore.Identity;

namespace PosTerminal.Net.Domain.Entities.Identities;

public class User : IdentityUser<int>
{
    public User()
    {
        GeneratedCode = Guid.NewGuid().ToString().Substring(0, 8);
    }

    public string Name { get; set; }
    public string FamilyName { get; set; }
    public string GeneratedCode { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<UserLogin> Logins { get; set; }
    public ICollection<UserClaim> Claims { get; set; }
    public ICollection<UserToken> Tokens { get; set; }
    public ICollection<Pos> Pos { get; } = new HashSet<Pos>();
    #region Navigation Properties


    #endregion

    public void AddPose(Pos pos)
    {
        Pos.Add(pos);
    }

}