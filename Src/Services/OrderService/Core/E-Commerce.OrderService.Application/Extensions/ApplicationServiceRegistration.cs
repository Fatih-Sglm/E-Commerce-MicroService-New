using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_Commerce.OrderService.Application.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServiceRegistration(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(opt => opt.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly);
        }
    }
}
