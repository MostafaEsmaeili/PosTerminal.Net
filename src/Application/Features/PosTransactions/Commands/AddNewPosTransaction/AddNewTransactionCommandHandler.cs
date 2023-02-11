using MediatR;
using PosTerminal.Net.Domain.Entities;
using TanvirArjel.EFCore.GenericRepository;

namespace PosTerminal.Net.Application.Features.PosTransactions.Commands.AddNewPosTransaction
{
    public sealed class AddNewTransactionCommandHandler : IRequestHandler<AddNewPosTransactionCommand, Guid>
    {
        private readonly IRepository _repository;

        public AddNewTransactionCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(AddNewPosTransactionCommand request, CancellationToken cancellationToken)
        {
            var posIdList =await _repository.GetListAsync<Pos, int>(condition: x => x.User.UserName == request.Username && x.PosTransactions.wh),
                                                                    selectExpression: x => x.Id,
                                                                    cancellationToken);
            PosTransaction transaction = new ()
        }
    }
}
