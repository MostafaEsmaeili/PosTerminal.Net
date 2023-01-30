using MediatR;
using PosTerminal.Net.Application.Models.Common;
using PosTerminal.Net.Application.Models.Jwt;

namespace PosTerminal.Net.Application.Features.Admin.Queries.GetToken;

public record AdminGetTokenQuery(string UserName, string Password) : IRequest<OperationResult<AccessToken>>;