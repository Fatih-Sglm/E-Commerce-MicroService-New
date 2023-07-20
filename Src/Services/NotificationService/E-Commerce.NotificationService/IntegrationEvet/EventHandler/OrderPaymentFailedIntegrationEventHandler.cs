using E_Commerce.NotificationService.IntegrationEvet.Event;
using Microsoft.Extensions.Logging;

namespace E_Commerce.NotificationService.IntegrationEvet.EventHandler
{
    public class OrderPaymentFailedIntegrationEventHandler
    {
        private readonly ILogger<OrderPaymentFailedIntegrationEventHandler> _logger;

        public OrderPaymentFailedIntegrationEventHandler(ILogger<OrderPaymentFailedIntegrationEventHandler> logger)
        {
            _logger = logger;
        }

        public Task HandleAsync(OrderPaymentFailedIntegrationEvent @event)
        {
            //todo send e-mail , sms or notification
            _logger.LogInformation($"{@event.OrderId} Id'li Siparşin Ödemesi Başarısız; Hata Nedeni: {@event.ErrorMessage}");
            return Task.CompletedTask;
        }
    }
}
