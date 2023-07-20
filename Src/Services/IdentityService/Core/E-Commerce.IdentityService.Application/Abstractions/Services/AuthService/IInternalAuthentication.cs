using E_Commerce.IdentityService.Application.Features.Auth.Command.Login.User;
using E_Commerce.IdentityService.Application.Features.Auth.Models;

namespace E_Commerce.IdentityService.Application.Abstractions.Services.AuthService
{
    public interface IInternalAuthentication
    {
        Task<LoginResponseDto> LoginAsync(LoginUserCommand command);
        Task<LoginResponseDto> RefreshTokenLoginAsync(string refreshToken);
    }
}
