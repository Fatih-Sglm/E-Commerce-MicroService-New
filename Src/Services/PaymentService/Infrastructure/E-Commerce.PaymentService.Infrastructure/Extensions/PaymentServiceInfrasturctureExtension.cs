using E_Commerce.PaymentService.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

namespace E_Commerce.PaymentService.Infrastructure.Extensions
{
    public static class PaymentServiceInfrasturctureExtension
    {
        public static void AddPaymentServiceInfrasturctureExtension(this IServiceCollection services, IConfiguration configuration)
        {
            StripeConfiguration.ApiKey = configuration.GetValue<string>("StripeSettings:SecretKey");
            services.AddTransient<IPaymentService, Services.PaymentService>();

            services
                .AddTransient<CustomerService>()
                .AddTransient<ChargeService>()
                .AddTransient<TokenService>();
        }
    }
}
