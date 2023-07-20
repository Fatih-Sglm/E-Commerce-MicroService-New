using E_Commerce.IdentityService.Application.Features.Auth.Models;

namespace E_Commerce.IdentityService.Application.Abstractions.Services.AuthService
{
    public interface IExternalAuthentication
    {

        Task<LoginResponseDto> GoogleLoginAsync();
        Task<LoginResponseDto> FacebookLoginAsync();
    }
}
