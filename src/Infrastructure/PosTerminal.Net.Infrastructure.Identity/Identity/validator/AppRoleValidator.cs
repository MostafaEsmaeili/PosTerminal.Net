﻿using Microsoft.AspNetCore.Identity;

namespace PosTerminal.Net.Infrastructure.Identity.Identity.validator;

public class AppRoleValidator : RoleValidator<Role>
{
    public AppRoleValidator(IdentityErrorDescriber errors) : base(errors)
    {

    }

    public override Task<IdentityResult> ValidateAsync(RoleManager<Role> manager, Role role)
    {
        return base.ValidateAsync(manager, role);
    }
}