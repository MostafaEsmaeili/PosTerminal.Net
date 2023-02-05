using CleanArc.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace PosTerminal.Net.Infrastructure.Identity.Identity.Store;

public class RoleStore : RoleStore<Role, ApplicationDbContext, int, UserRole, RoleClaim>
{
    public RoleStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
    {
    }
}