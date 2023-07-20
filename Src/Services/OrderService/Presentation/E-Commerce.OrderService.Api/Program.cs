using E_Commerce.OrderService.Api.Extensions;
using E_Commerce.OrderService.Application.Extensions;
using E_Commerce.OrderService.Persistence.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider((context, options) =>
{
    options.ValidateOnBuild = false;
    options.ValidateScopes = false;
});
// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddAuthServices(builder.Configuration);
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddApplicationServiceRegistration();
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
builder.Services.ConfigureEventHandlers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddLogging(cfg => cfg.AddConsole());
builder.Services.RabbitMqRegister(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrderService.Api", Version = "v1" });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Start();
app.RegisterWithConsul(app.Lifetime);
app.WaitForShutdown();
