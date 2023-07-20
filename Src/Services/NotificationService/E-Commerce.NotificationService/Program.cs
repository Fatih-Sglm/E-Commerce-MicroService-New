using E_Commerce.NotificationService.IntegrationEvet.EventHandler;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Reflection;






ServiceCollection services = new();
IConfiguration configuration = BuildConfiguration();

ConfigureService(services);


var sp = services.BuildServiceProvider();

Console.WriteLine("App run");

while (true)
{
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
    if (keyInfo.Key == ConsoleKey.Q && keyInfo.Modifiers == (ConsoleModifiers.Control | ConsoleModifiers.Shift))
    {
        break;
    }
}

void ConfigureService(ServiceCollection services)
{
    services.AddLogging(cfg => cfg.AddConsole());
    RabbitMqRegister(services);
}
void RabbitMqRegister(IServiceCollection services)
{
    services.AddLogging(cfg => cfg.AddConsole());

    var host = configuration["RabbitMq:HostName"];
    var port = configuration["RabbitMq:Port"];
    var userName = configuration["RabbitMq:UserName"];
    var password = configuration["RabbitMq:Password"];

    //MassTransit DI Injection
    services.AddMassTransit(opt =>
    {
        opt.UsingRabbitMq((ctx, cfg) =>
        {
            cfg.Host($"{host}:{port}", opt =>
            {
                opt.Username(userName);
                opt.Password(password);
            });
            cfg.ConfigureEndpoints(ctx);
        });
        opt.AddConsumer<UserNotificationIntegrationEventHandler>();
    });
}
IConfiguration BuildConfiguration()
{
    var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName).
          AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).AddEnvironmentVariables()
          .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
          .Build();

    services.AddSingleton<IConfiguration>(configuration);
    return configuration;
}
