using MediatR;
namespace PosTerminal.Net.Application.Features.Order.Queries.GetUserOrders;

public record GetUserOrdersQueryModel(int UserId) : IRequest<List<GetUsersQueryResultModel>>;