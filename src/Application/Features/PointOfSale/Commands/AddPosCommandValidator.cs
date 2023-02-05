

using FluentValidation;
using PosTerminal.Net.Domain.Entities;
using TanvirArjel.EFCore.GenericRepository;

namespace PosTerminal.Net.Application.Features.PointOfSale.Commands
{
    public class AddPosCommandValidator : AbstractValidator<AddPosCommand>
    {
        private readonly IRepository _PosRepository;

        public AddPosCommandValidator(IRepository posRepository)
        {
            _PosRepository = posRepository;
            RuleFor(x=>x.TerminalId).NotNull().NotEmpty().MustAsync(ShouldBeUniqueTerminalId);
            RuleFor(x=>x.Bank).IsInEnum();

        }

        private Task<bool> ShouldBeUniqueTerminalId(int terminalId, CancellationToken  cancellationToken)
        {
          return  _PosRepository.ExistsAsync<Pos>(x=>x.TerminalId == terminalId, cancellationToken);
        }
    }
}
