using MediatR;
namespace PosTerminal.Net.Application.Features.PointOfSale.Commands.AddPos;

public record AddPosCommand(int TerminalId, Bank Bank, string? Description) :
    IRequest<bool>;