﻿using MediatR;
using PosTerminal.Net.Application.Contracts;
using PosTerminal.Net.Application.Contracts.Identity;
using PosTerminal.Net.Application.Features.Users.Queries.GenerateUserToken.Model;
using PosTerminal.Net.Application.Models.Common;
using PosTerminal.Net.Application.Models.Jwt;

namespace PosTerminal.Net.Application.Features.Users.Queries.GenerateUserToken;

public class GenerateUserTokenHandler : IRequestHandler<GenerateUserTokenQuery, OperationResult<AccessToken>>
{
    private readonly IJwtService _jwtService;
    private readonly IAppUserManager _userManager;


    public GenerateUserTokenHandler(IJwtService jwtService, IAppUserManager userManager)
    {
        _jwtService = jwtService;
        _userManager = userManager;
    }

    public async Task<OperationResult<AccessToken>> Handle(GenerateUserTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserByCode(request.UserKey);

        if (user is null)
            return OperationResult<AccessToken>.FailureResult("کاربر یافت نشد");

        var result = await _userManager.VerifyUserCode(
            user, request.Code);


        if (!result)
            return OperationResult<AccessToken>.FailureResult("کد وارد شده صحیح نیست");


        var token = await _jwtService.GenerateAsync(user);

        return OperationResult<AccessToken>.SuccessResult(token);
    }
}