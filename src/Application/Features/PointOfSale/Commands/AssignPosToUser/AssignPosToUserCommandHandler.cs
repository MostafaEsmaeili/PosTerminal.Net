using MediatR;
using PosTerminal.Net.Domain.Entities;
using TanvirArjel.EFCore.GenericRepository;

namespace PosTerminal.Net.Application.Features.PointOfSale.Commands.AssignPosToUser
{
    public class AssignPosToUserCommandHandler : AsyncRequestHandler<AssignPosToUserCommand>
    {
        private readonly IRepository _repository;

        public AssignPosToUserCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        protected override async Task Handle(AssignPosToUserCommand request, CancellationToken cancellationToken)
        {
            var userId = await _repository.GetAsync<User, int>(condition: entity => entity.UserName == request.Username,
                selectExpression: projection => projection.Id,
                cancellationToken: cancellationToken);

            var pos = await _repository.GetByIdAsync<Pos>(request.PosId, cancellationToken);
            pos.UserId = userId;
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}
