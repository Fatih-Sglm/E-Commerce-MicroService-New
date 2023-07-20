using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Application.Abstractions.Services;
using E_Commerce.OrderService.Persistence.Concrete.Repository;
using E_Commerce.OrderService.Persistence.Concrete.Services;
using E_Commerce.OrderService.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.OrderService.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IBuyerService, BuyerService>();

            services.AddDbContext<OrderDbContext>(opt => opt.
                                 UseSqlServer(string.Format(configuration.GetConnectionString("MSS")!, configuration["SqlPass"])));

            services.AddSingleton(sp => sp.DbInitialize());

        }
        public static IServiceProvider DbInitialize(this IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
            context.Database.Migrate();
            return provider;
        }
    }
}
