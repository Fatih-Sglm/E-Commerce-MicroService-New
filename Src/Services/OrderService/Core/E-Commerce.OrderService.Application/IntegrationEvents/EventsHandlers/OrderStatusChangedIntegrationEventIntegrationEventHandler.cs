using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Application.IntegrationEvents.Events;
using E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace E_Commerce.OrderService.Application.IntegrationEvents.EventsHandlers
{
    public class OrderStatusChangedIntegrationEventIntegrationEventHandler : IConsumer<OrderStatusChangedIntegrationEvent>
    {
        private readonly ILogger<OrderStatusChangedIntegrationEventIntegrationEventHandler> _logger;
        private readonly IOrderRepository _orderRepository;

        public OrderStatusChangedIntegrationEventIntegrationEventHandler(ILogger<OrderStatusChangedIntegrationEventIntegrationEventHandler> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public async Task Consume(ConsumeContext<OrderStatusChangedIntegrationEvent> context)
        {
            OrderStatus orderStatus = OrderStatus.FromName(context.Message.OrderStatus);
            Order? order = await _orderRepository.GetAsync(x => x.Id == context.Message.OrderId);
            ArgumentNullException.ThrowIfNull(order, nameof(order));
            order.SetOrderStatus(orderStatus);
            _orderRepository.Update(order);
            bool result = await _orderRepository.SaveChangesAsync();
            var message = result ? $"The Order Status column of the item with id {context.Message.Id} has been successfully updated to {context.Message.OrderStatus}." :
                $"An error occurred while updating the order status column of the order with id {context.Message.Id}.";
            _logger.LogInformation(message);
        }
    }
}
