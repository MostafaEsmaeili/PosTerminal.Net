using FluentValidation;
using PosTerminal.Net.Domain.Entities;
using PosTerminal.Net.Domain.Enums;
using TanvirArjel.EFCore.GenericRepository;

namespace PosTerminal.Net.Application.Features.PosTransactions.Commands.AddNewPosTransaction;
public class AddNewPosTransactionValidator : AbstractValidator<AddNewPosTransactionCommand>
{
    private readonly IRepository _repository;

    public AddNewPosTransactionValidator(IRepository repository)
    {
        _repository = repository;
        RuleFor(x=>x.Amount).GreaterThan(0);

        RuleFor(x => x.Username).MustAsync(UserShouldExist)
                                .WithMessage(x => $"User {x.Username} Does Not Exists")
                                .MustAsync(UserShouldHaveActivePos)
                                .WithMessage(x => $"User {x.Username} Does not have any active pos");

        RuleFor(x => x.UniqueId).NotNull()
                              .NotEmpty()
                              .MustAsync(ShouldNotHavePendingTransactionForUniqueId)
                              .WithMessage(x => $"{x.UniqueId} Already has an active transaction")
                              .MustAsync(ShouldNotHavePendingTransactionForUser)
                              .WithMessage(x => $"User : {x.Username} Already has an active transaction")
            ;

        RuleFor(x => x.PreferredPos).IsInEnum()
                                  .MustAsync(UserShouldHaveActivePreffredPos)
                                  .When(x=>x.PreferredPos is not null);
    }

    private  Task<bool> UserShouldHaveActivePreffredPos(AddNewPosTransactionCommand model, Bank? bank, CancellationToken cancellatio)
    {
        return  _repository.ExistsAsync <Pos>(x=>x.User.Name == model.Username && x.Bank == bank);
    }
    private async Task<bool> ShouldNotHavePendingTransactionForUniqueId(AddNewPosTransactionCommand model, string uniqueId, CancellationToken cancellation)
    {
       return !await _repository.ExistsAsync<PosTransaction>(t => t.UniqueId == uniqueId && t.IsPending(), cancellation);
    }
    private async Task<bool> ShouldNotHavePendingTransactionForUser(AddNewPosTransactionCommand model,string uniqueId, CancellationToken cancellation)
    {
        return !await _repository.ExistsAsync<PosTransaction>(t => t.Pos.User.UserName == model .Username && t.IsPending(), cancellation);
    }
    private Task<bool> UserShouldHaveActivePos(string username, CancellationToken cancellationToken)
    {
        return _repository.ExistsAsync<Pos>(x => x.User.UserName == username && x.IsActive == true, cancellationToken);
    }

    private Task<bool> UserShouldExist(string username, CancellationToken cancellationToken)
    {
        return _repository.ExistsAsync<User>(x => x.UserName == username, cancellationToken);
    }
}