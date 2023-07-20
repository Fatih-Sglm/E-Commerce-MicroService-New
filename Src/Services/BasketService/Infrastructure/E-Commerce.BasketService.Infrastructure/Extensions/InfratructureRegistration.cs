using E_Commerce.BasketService.Application.Abstractions.Services;
using E_Commerce.BasketService.Infrastructure.Concrete.Services;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.BasketService.Infrastructure.Extensions
{
    public static class InfratructureRegistration
    {
        public static void AddInfratructureRegistration(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();
        }
    }
}
