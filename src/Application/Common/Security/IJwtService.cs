using System.Security.Claims;
using PosTerminal.Net.Application.Models.Jwt;

namespace PosTerminal.Net.Application.Common.Security;

public interface IJwtService
{
    Task<AccessToken> GenerateAsync(User user);
    Task<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    Task<AccessToken> GenerateByPhoneNumberAsync(string phoneNumber);
    Task<AccessToken> RefreshToken(string refreshTokenId);
}