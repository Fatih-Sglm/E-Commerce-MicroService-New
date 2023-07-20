using E_Commerce.IdentityService.Api.Extensions;
using E_Commerce.IdentityService.Application.Extensions;
using E_Commerce.IdentityService.Infrastructure.Extensions;
using E_Commerce.IdentityService.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseDefaultServiceProvider((context, options) =>
{
    options.ValidateOnBuild = false;
    options.ValidateScopes = false;
});
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddAuthServices(builder.Configuration);
builder.Services.RabbitMqRegister(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.AddWebApplicaitonService();
await app.DbInitialize();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Start();
app.RegisterWithConsul(app.Lifetime, builder.Configuration);
app.WaitForShutdown();