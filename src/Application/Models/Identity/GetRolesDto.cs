using PosTerminal.Net.Application.Profiles;
using PosTerminal.Net.Domain.Entities.Identities;

namespace PosTerminal.Net.Application.Models.Identity;

public class GetRolesDto : ICreateMapper<Role>
{
    public string Id { get; set; }
    public string Name { get; set; }
}