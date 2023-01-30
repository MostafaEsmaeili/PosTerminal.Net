using MediatR;
using PosTerminal.Net.Application.Models.Common;
using PosTerminal.Net.Application.Models.Jwt;

namespace PosTerminal.Net.Application.Features.Users.Commands.ConfirmPhoneNumber;

public record ConfirmPhoneNumberCommand(string UserKey, string Code) : IRequest<OperationResult<AccessToken>>;
