using MediatR;
using PosTerminal.Net.Domain.Entities;
using TanvirArjel.EFCore.GenericRepository;

namespace PosTerminal.Net.Application.Features.PointOfSale.Commands.AddPos;

internal class AddPosCommandHandler : IRequestHandler<AddPosCommand, bool>
{
    private readonly IRepository _Repository;

    public AddPosCommandHandler(IRepository repository)
    {
        _Repository = repository;
    }

    public async Task<bool> Handle(AddPosCommand request, CancellationToken cancellationToken)
    {
        var entity = new Pos(request.TerminalId, request.Bank)
        {
            Description = request.Description
        };
        _Repository.Add(entity);
        return await _Repository.SaveChangesAsync(cancellationToken) > 0;
    }

}