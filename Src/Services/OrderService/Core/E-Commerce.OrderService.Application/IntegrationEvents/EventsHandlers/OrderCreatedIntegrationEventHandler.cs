using E_Commerce.OrderService.Application.Features.Orders.Command.CreateOrder;
using E_Commerce.OrderService.Application.IntegrationEvents.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace E_Commerce.OrderService.Application.IntegrationEvents.EventsHandlers
{
    public class OrderCreatedIntegrationEventHandler : IConsumer<OrderCreatedIntegrationEvent>
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderCreatedIntegrationEventHandler> _logger;

        public OrderCreatedIntegrationEventHandler(IMediator mediator, ILogger<OrderCreatedIntegrationEventHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderCreatedIntegrationEvent> context)
        {

            _logger.LogInformation("Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", context.Message.Id, typeof(OrderCreatedIntegrationEvent).Namespace, context.Message.GetType());

            CreateOrderCommand createOrderCommand = new(
            context.Message.Basket!.Items, context.Message.Basket.TotalPrice,
            context.Message.UserName, context.Message.Name, context.Message.Email,
            context.Message.City, context.Message.Street, context.Message.State, context.Message.Country, context.Message.ZipCode,
            context.Message.Alias, context.Message.CreditCard, context.Message.CardTypeId, context.Message.WillPaymentRecorded);
            await _mediator.Send(createOrderCommand);
        }
    }
}
