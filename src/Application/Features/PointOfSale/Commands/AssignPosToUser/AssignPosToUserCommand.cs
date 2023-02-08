using MediatR;

namespace PosTerminal.Net.Application.Features.PointOfSale.Commands.AssignPosToUser;
public record AssignPosToUserCommand(string Username, int PosId) : IRequest;