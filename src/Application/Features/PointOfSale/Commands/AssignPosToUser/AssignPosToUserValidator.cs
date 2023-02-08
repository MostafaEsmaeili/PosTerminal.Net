using FluentValidation;
using PosTerminal.Net.Domain.Entities;
using TanvirArjel.EFCore.GenericRepository;

namespace PosTerminal.Net.Application.Features.PointOfSale.Commands.AssignPosToUser;
public class AssignPosToUserValidator : AbstractValidator<AssignPosToUserCommand>
{
    private readonly IRepository _repository;

    public AssignPosToUserValidator(IRepository repository)
    {
        this._repository = repository;
        RuleFor(x => x.PosId).MustAsync(ShouldBeValidPos);
        RuleFor(x => x.Username).MustAsync(ShouldBeValidUser)
        .WithMessage(x => $"The username : {x.Username} is not valid")
        .MustAsync(ThePosShouldNotHaveAnyOtherUser)
        .WithMessage(x => "The Pos Already assigned to another user");



    }

    private Task<bool> ThePosShouldNotHaveAnyOtherUser(AssignPosToUserCommand model,
                                                       string username,
                                                       CancellationToken cancellationToken)
    {
        return _repository.ExistsAsync<Pos>(pos => pos.Id == model.PosId
                && model.Username == pos.User.UserName, cancellationToken);
    }

    private Task<bool> ShouldBeValidPos(int posId, CancellationToken cancellationToken)
    {
        return _repository.ExistsAsync<Pos>(x => x.Id == posId, cancellationToken);
    }

    private Task<bool> ShouldBeValidUser(string username, CancellationToken cancellationToken)
    {
        return _repository.ExistsAsync<User>(x => x.UserName == username, cancellationToken);
    }
}