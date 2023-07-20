using E_Commerce.IdentityService.Application.Features.Auth.Models;
using E_Commerce.IdentityService.Domain.Entities.Identity;

namespace E_Commerce.IdentityService.Application.Abstractions.Services.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AppUser user, IList<string> Roles);

        string CreateRefreshToken();
    }
}
