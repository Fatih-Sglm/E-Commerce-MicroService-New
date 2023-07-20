using E_Commerce.OrderService.Application.Abstractions.Services;
using E_Commerce.OrderService.Infrastructure.Concrete.Services;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.OrderService.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();
        }
    }
}
