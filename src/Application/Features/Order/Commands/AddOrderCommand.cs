using MediatR;
using PosTerminal.Net.Application.Models.Common;

namespace PosTerminal.Net.Application.Features.Order.Commands;

public record AddOrderCommand(int UserId, string OrderName) : IRequest<OperationResult<bool>>;