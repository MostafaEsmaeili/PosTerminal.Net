using PosTerminal.Net.Application.Profiles;

namespace PosTerminal.Net.Application.Features.Users.Queries.GetUsers.Model;

public record GetUsersQueryResponseModel : ICreateMapper<User>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public int UserId { get; set; }
}