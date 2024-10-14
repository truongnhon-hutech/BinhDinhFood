using BinhDinhFood.Application.Common.Models.AuthIdentity.UsersIdentity;
using BinhDinhFood.Domain.Entities.Auth;

namespace BinhDinhFood.Application.Common.Interfaces;
public interface IAuthIdentityService
{
    Task<TokenResult> RefreshTokenAsync(string token, CancellationToken cancellationToken);
    Task<TokenResult> Authenticate(LoginRequest request, CancellationToken cancellationToken);
    Task Register(RegisterRequest request, CancellationToken cancellationToken);
    Task<UserViewModel> Get(CancellationToken cancellationToken);
    Task<TokenResult> SignInFacebook(string accessToken, CancellationToken cancellationToken);
    Task<TokenResult> SignInGoogle(string accessToken, CancellationToken cancellationToken);
    Task<TokenResult> SignInApple(string fullName, string identityToken, CancellationToken cancellationToken);
    Task<ForgotPassword> SendPasswordResetCode(SendPasswordResetCodeRequest request, CancellationToken cancellationToken);
    Task ResetPassword(ResetPasswordRequest request, CancellationToken cancellationToken);
}
