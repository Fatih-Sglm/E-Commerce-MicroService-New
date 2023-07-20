using E_Commerce.IdentityService.Application.Abstractions.Services.Jwt;
using E_Commerce.IdentityService.Application.Features.Auth.Models;
using E_Commerce.IdentityService.Domain.Entities.Identity;
using E_Commerce.IdentityService.Infrastructure.Concretes.Services.JwtHelper.Configuration;
using E_Commerce.IdentityService.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace E_Commerce.IdentityService.Infrastructure.Concretes.Services.JwtHelper
{
    internal class TokenHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private readonly DateTime _accessTokenExpiration;

        public TokenHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>()!;
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
        public string CreateRefreshToken()
        {
            byte[] number = new byte[64];
            using RandomNumberGenerator generator = RandomNumberGenerator.Create();
            generator.GetBytes(number);
            return Convert.ToBase64String(number);
        }

        public AccessToken CreateToken(AppUser user, IList<string> roles)
        {
            SecurityKey securityKey = CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = CreateSigningCredentials(securityKey);
            JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, user, roles, signingCredentials);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string? token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, AppUser user, IList<string> roles,
                                                   SigningCredentials signingCredentials)
        {
            JwtSecurityToken jwt = new(
                tokenOptions.Issuer,
                tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, roles),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private static IEnumerable<Claim> SetClaims(AppUser user, IList<string> roles)
        {
            List<Claim> claims = new();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email!);
            claims.AddUserName(user.UserName!);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(roles.ToArray());
            return claims;
        }



        private static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }

        private static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
