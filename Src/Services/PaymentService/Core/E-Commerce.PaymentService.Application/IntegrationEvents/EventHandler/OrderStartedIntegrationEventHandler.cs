using E_Commerce.PaymentService.Application.IntegrationEvents.Events;
using E_Commerce.PaymentService.Application.Services;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace E_Commerce.PaymentService.Application.IntegrationEvents.EventHandler
{
    public class OrderStartedIntegrationEventHandler : IConsumer<OrderStartedIntegrationEvent>
    {
        private readonly IBus _eventBus;
        private readonly ILogger<OrderStartedIntegrationEventHandler> _logger;
        private readonly IPaymentService _paymentService;

        public OrderStartedIntegrationEventHandler(IBus eventBus, ILogger<OrderStartedIntegrationEventHandler> logger, IPaymentService paymentService)
        {
            _eventBus = eventBus;
            _logger = logger;
            _paymentService = paymentService;
        }

        public async Task Consume(ConsumeContext<OrderStartedIntegrationEvent> context)
        {
            var payment = await _paymentService.Payment(new(context.Message.Name, context.Message.Email, "USD", context.Message.Amount, context.Message.CreditCard), default);
            if (payment.IsPaid)
            {
                OrderPaymentSuccessIntegrationEvent paymentEvent = new(context.Message.OrderId, context.Message.Name, context.Message.Email, context.Message.OrderNumber, context.Message.OrderDate);
                await _eventBus.Publish(paymentEvent);
            }
            else
            {
                OrderPaymentFailedIntegrationEvent paymentEvent = new(context.Message.OrderId, context.Message.Name, context.Message.Email, context.Message.OrderNumber, "Error", context.Message.OrderDate);
                await _eventBus.Publish(paymentEvent);
            }
            _logger.LogInformation($"OrderStartedIntegrationEventHandler in " +
            $"Payment service is fired with paymentsucces:{payment.IsPaid} , orderId: {context.Message.OrderId}");
        }
    }
}
