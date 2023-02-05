using Microsoft.AspNetCore.Identity;

namespace PosTerminal.Net.Infrastructure.Identity.Identity.validator;

public class AppUserValidator : UserValidator<User>
{
    public AppUserValidator(IdentityErrorDescriber errors) : base(errors)
    {

    }

    public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
    {
        var result = await base.ValidateAsync(manager, user);

        return result;
    }


}