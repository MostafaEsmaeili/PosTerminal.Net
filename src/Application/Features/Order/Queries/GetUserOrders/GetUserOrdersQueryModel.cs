using MediatR;
using PosTerminal.Net.Application.Models.Common;

namespace PosTerminal.Net.Application.Features.Order.Queries.GetUserOrders;

public record GetUserOrdersQueryModel(int UserId) : IRequest<OperationResult<List<GetUsersQueryResultModel>>>;