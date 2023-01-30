﻿using MediatR;
using PosTerminal.Net.Application.Contracts;
using PosTerminal.Net.Application.Contracts.Identity;
using PosTerminal.Net.Application.Models.Common;
using PosTerminal.Net.Application.Models.Jwt;

namespace PosTerminal.Net.Application.Features.Users.Commands.ConfirmPhoneNumber;

public class ConfirmPhoneNumberCommandHandler : IRequestHandler<ConfirmPhoneNumberCommand, OperationResult<AccessToken>>
{
    private readonly IJwtService _jwtService;
    private readonly IAppUserManager _userManager;

    public ConfirmPhoneNumberCommandHandler(IJwtService jwtService, IAppUserManager userManager)
    {
        _jwtService = jwtService;
        _userManager = userManager;
    }

    public async Task<OperationResult<AccessToken>> Handle(ConfirmPhoneNumberCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByCode(request.UserKey);

        if (user is null)
        {
            return OperationResult<AccessToken>.FailureResult("کاربر یافت نشد");
        }

        var result = await _userManager.ChangePhoneNumber(user, user.PhoneNumber, request.Code);

        if (result.Succeeded)
        {
            var token = await _jwtService.GenerateAsync(user);
            return OperationResult<AccessToken>.SuccessResult(token);
        }
        return OperationResult<AccessToken>.FailureResult(string.Join(",", result.Errors.Select(c => c.Description)));

    }
}