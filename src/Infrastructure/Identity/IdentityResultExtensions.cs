using Microsoft.AspNetCore.Identity;
using PosTerminal.Net.Application.Common.Models;

namespace PosTerminal.Net.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
