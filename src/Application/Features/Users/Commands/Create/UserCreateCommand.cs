using MediatR;
using PosTerminal.Net.Application.Models.Common;

namespace PosTerminal.Net.Application.Features.Users.Commands.Create;

public record UserCreateCommand(
string UserName,
string FirstName,
string LastName,
string PhoneNumber) : IRequest<OperationResult<UserCreateCommandResult>>;