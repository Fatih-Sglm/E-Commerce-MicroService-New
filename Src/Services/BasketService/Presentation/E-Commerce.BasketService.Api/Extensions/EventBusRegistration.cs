using E_Commerce.BasketService.Application.IntegrationEvents.EventsHandler;
using MassTransit;

namespace E_Commerce.BasketService.Api.Extensions
{
    public static class EventBusRegistration
    {
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

                opt.AddConsumer<OrderCreatedIntegrationEventEventEventHandler>();
            });
            return services;
        }
    }
}
