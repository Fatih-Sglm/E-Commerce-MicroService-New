using E_Commerce.CatalogService.Api.Extensions;
using E_Commerce.CatalogService.Application.Extensions;
using E_Commerce.CatalogService.Infrastructure.Extensions;
using E_Commerce.CatalogService.Infrastructure.Services.Storage.CloudinaryStorage;
using E_Commerce.CatalogService.Persistence.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddStorage<CloudinaryStorage>();
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddAuthServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddCloudinary(builder.Configuration);
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);
builder.Services.AddApplicationServiceRegistration();
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
app.AddWebApplicationService();
await app.DbInitialize();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Start();
app.RegisterWithConsul(app.Lifetime, builder.Configuration);
app.WaitForShutdown();