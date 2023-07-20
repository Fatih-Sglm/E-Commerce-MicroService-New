using E_Commerce.IdentityService.Domain.Entities;
using E_Commerce.IdentityService.Domain.Entities.Identity;

namespace E_Commerce.IdentityService.Application.Abstractions.Services
{
    public interface IRefreshTokenService
    {
        Task InsertRefreshToken(AppUser appuser, string token, DateTime refreshTokenExpirationTime);
        Task<RefreshToken?> GetRefreshTokenByToken(string refreshToken);

    }
}
