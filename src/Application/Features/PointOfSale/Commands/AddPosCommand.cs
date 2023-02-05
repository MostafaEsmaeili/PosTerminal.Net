using MediatR;
using PosTerminal.Net.Application.Models.Common;
namespace PosTerminal.Net.Application.Features.PointOfSale.Commands;

public record AddPosCommand(int TerminalId,Bank Bank, string? Description) :
    IRequest<OperationResult<bool>>;