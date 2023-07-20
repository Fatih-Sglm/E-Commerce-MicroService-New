using E_Commerce.OrderService.Application.IntegrationEvents.EventsHandlers;
using MassTransit;

namespace E_Commerce.OrderService.Api.Extensions
{
    public static class EventBusRegistration
    {
        public static void ConfigureEventHandlers(this IServiceCollection services)
        {
            services.AddTransient<OrderCreatedIntegrationEventHandler>();
            services.AddTransient<OrderStatusChangedIntegrationEventIntegrationEventHandler>();
        }
        public static IServiceCollection RabbitMqRegister(this IServiceCollection services, IConfiguration configuration)
        {
            var host = configuration["RabbitMq:HostName"];
            var port = configuration["RabbitMq:Port"];
            var userName = configuration["RabbitMq:UserName"];
            var password = configuration["RabbitMq:Password"];

            //MassTransit DI Injection
            services.AddMassTransit(opt =>
            {
                //Add RabbitMq Configurations
                opt.UsingRabbitMq((ctx, cfg) =>
                {
                    //Set Host Url
                    cfg.Host($"{host}:{port}", opt =>
                    {
                        opt.Username(userName);
                        opt.Password(password);
                    });

                    cfg.ConfigureEndpoints(ctx);

                });

                //opt.AddConsumers(Assembly.GetExecutingAssembly());

                opt.AddConsumer<OrderCreatedIntegrationEventHandler>();
                opt.AddConsumer<OrderStatusChangedIntegrationEventIntegrationEventHandler>();
            });
            return services;
        }
    }
}
