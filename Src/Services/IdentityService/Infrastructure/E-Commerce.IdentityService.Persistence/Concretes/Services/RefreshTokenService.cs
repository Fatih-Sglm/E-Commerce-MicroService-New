using E_Commerce.IdentityService.Application.Abstractions.Repositories.Common;
using E_Commerce.IdentityService.Application.Abstractions.Services;
using E_Commerce.IdentityService.Domain.Entities;
using E_Commerce.IdentityService.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.IdentityService.Persistence.Concretes.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IGenericRepository<RefreshToken> _refreshTokenRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public RefreshTokenService(IGenericRepository<RefreshToken> refreshTokenRepository, IHttpContextAccessor httpContextAccessor)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<RefreshToken?> GetRefreshTokenByToken(string refreshToken)
        {
            return await _refreshTokenRepository.
                GetAsync(x => x.Token == refreshToken && x.Expires > DateTime.Now, x => x.Include(z => z.User));

        }

        public async Task InsertRefreshToken(AppUser appUser, string token, DateTime refreshTokenExpirationTime)
        {
            if (token == null)
                throw new Exception("Token İs null");

            if (refreshTokenExpirationTime < DateTime.Now.AddMinutes(10))
                throw new Exception("Invalid Expiration Time");

            RefreshToken refreshToken = new()
            {
                CreatedByIp = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.MapToIPv4()?.ToString(),
                Expires = refreshTokenExpirationTime,
                Token = token,
                User = appUser,
            };

            await _refreshTokenRepository.AddAsync(refreshToken);
        }
    }
}
