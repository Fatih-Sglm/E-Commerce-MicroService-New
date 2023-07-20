using E_Commerce.BasketService.Application.Abstractions.Repository;
using E_Commerce.BasketService.Application.IntegrationEvents.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace E_Commerce.BasketService.Application.IntegrationEvents.EventsHandler
{
    public class OrderCreatedIntegrationEventEventEventHandler : IConsumer<OrderCreatedIntegrationEvent>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly ILogger<OrderCreatedIntegrationEvent> _logger;

        public OrderCreatedIntegrationEventEventEventHandler(IBasketRepository repository, ILogger<OrderCreatedIntegrationEvent> logger)
        {
            _basketRepository = repository;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderCreatedIntegrationEvent> @event)
        {
            await Task.Delay(500);
            _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at BasketService.Api - ({@IntegrationEvent})", @event);
            //await _basketRepository.DeleteBasketAsync(@event.Message.UserName);
        }
    }
}
