using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace E_Commerce.CatalogService.Api.Extensions
{
    public static class AuthConfiguration
    {
        public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication()
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = configuration["TokenOptions:Issuer"],
                  ValidAudience = configuration["TokenOptions:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenOptions:SecurityKey"]!)),
                  LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null && expires > DateTime.UtcNow,
              };
          });

            services.AddAuthorization(options =>
            {
            });
        }
    }
}
