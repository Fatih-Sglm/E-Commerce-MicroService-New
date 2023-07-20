using Consul;

namespace E_Commerce.CatalogService.Api.Extensions
{
    public static class ConsulRegistration
    {
        public static void ConfigureConsul(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(cfg =>
            {
                var address = configuration["ConsulConfig:ConsulAddress"];
                cfg.Address = new Uri(address!);
            }));
        }

        public static void RegisterWithConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, IConfiguration configuration)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();

            var loggingFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();

            var logger = loggingFactory.CreateLogger<IApplicationBuilder>();

            var registration = configuration.GetSection("ConsulConfig:Profile").Get<AgentServiceRegistration>();

            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration!.ID).Wait();
            consulClient.Agent.ServiceRegister(registration).Wait();

            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Deregistering from Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

        }
    }
}
