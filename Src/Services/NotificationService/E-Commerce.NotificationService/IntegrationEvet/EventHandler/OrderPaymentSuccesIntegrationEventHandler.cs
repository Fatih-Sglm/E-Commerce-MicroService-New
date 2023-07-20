using E_Commerce.NotificationService.IntegrationEvet.Event;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace E_Commerce.NotificationService.IntegrationEvet.EventHandler
{
    public class OrderPaymentSuccesIntegrationEventHandler : IConsumer<OrderPaymentSuccessIntegrationEvent>
    {
        private readonly ILogger<OrderPaymentSuccesIntegrationEventHandler> _logger;

        public OrderPaymentSuccesIntegrationEventHandler(ILogger<OrderPaymentSuccesIntegrationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<OrderPaymentSuccessIntegrationEvent> context)
        {
            //todo send e-mail , sms or notification
            _logger.LogInformation($"{context.Message.OrderId} Id li Siparişin Ödemesi Başarılı");
            return Task.CompletedTask;
        }
    }
}
