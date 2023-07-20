using E_Commerce.IdentityService.Application.Abstractions.Services.Jwt;
using E_Commerce.IdentityService.Infrastructure.Concretes.Services.JwtHelper;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.IdentityService.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHelper, TokenHelper>();
        }
    }
}
