using MediatR;
using PosTerminal.Net.Application.Models.Common;

namespace PosTerminal.Net.Application.Features.Users.Queries.TokenRequest;

public record UserTokenRequestQuery(string UserPhoneNumber) : IRequest<OperationResult<UserTokenRequestQueryResult>>;