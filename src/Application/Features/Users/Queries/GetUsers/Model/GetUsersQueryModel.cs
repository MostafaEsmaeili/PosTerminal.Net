using MediatR;
using PosTerminal.Net.Application.Models.Common;

namespace PosTerminal.Net.Application.Features.Users.Queries.GetUsers.Model;

public record GetUsersQueryModel : IRequest<OperationResult<List<GetUsersQueryResponseModel>>>;