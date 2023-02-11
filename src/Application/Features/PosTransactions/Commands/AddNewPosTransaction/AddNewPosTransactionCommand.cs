using MediatR;
using PosTerminal.Net.Domain.Enums;

namespace PosTerminal.Net.Application.Features.PosTransactions.Commands.AddNewPosTransaction;
public record AddNewPosTransactionCommand(string Username,
                                          decimal Amount,
                                          string UniqueId,
                                          Bank? PreferredPos) : IRequest<Guid>;
