using E_Commerce.PaymentService.Application.IntegrationEvents.EventHandler;
using E_Commerce.PaymentService.Infrastructure.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddLogging(cfg => cfg.AddConsole());
        builder.Services.AddTransient<OrderStartedIntegrationEventHandler>();
        builder.Services.AddPaymentServiceInfrasturctureExtension(builder.Configuration);
        builder.Services.RabbitMqRegister(builder.Configuration);


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}