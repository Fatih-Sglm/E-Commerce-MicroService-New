using Microsoft.Extensions.DependencyInjection;
using TechBuddy.Extension.Validation.Extensions;

namespace E_Commerce.BasketService.Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddTechBuddyValidator();
        }
    }
}
