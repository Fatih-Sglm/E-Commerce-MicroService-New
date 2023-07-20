using E_Commerce.IdentityService.Application.Exceptions;
using E_Commerce.IdentityService.Application.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Reflection;
using TechBuddy.Extension.Validation.Extensions;
using TechBuddy.Extensions.AspNetCore.ExceptionHandling;

namespace E_Commerce.IdentityService.Application.Extensions
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(opt => opt.RegisterServicesFromAssembly(assembly));
            services.AddAutoMapper(assembly);
            services.AddTechBuddyValidator(opt =>
            {
                opt.UseModelProvider<CustomeErrorProvider>();
            });

        }
        public static void AddWebApplicaitonService(this WebApplication app)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == Environments.Development;

            app.ConfigureTechBuddyExceptionHandling(opt =>
            {

                AddCustomErroHandler<Exception>(opt, HttpStatusCode.InternalServerError, isDevelopment);
                AddCustomErroHandler<IdentityException>(opt, HttpStatusCode.BadRequest, isDevelopment);
                AddCustomErroHandler<NotFoundException>(opt, HttpStatusCode.NotFound, isDevelopment);
            });
        }

        private static void AddCustomErroHandler<T>(ExceptionHandlingOptions opt, HttpStatusCode httpStatusCode, bool isDevelopment) where T : Exception
        {
            opt.AddCustomHandler<T>((context, ex, logger) =>
            {

                var obj = ResponseDto<NoContent>.Failed(/*isDevelopment ? ex.ToString() :*/ ex.Message);
                context.Response.StatusCode = (int)httpStatusCode;
                return context.Response.WriteAsJsonAsync(obj);
            });
        }
    }
}
