using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Application.IntegrationEvents.Events;
using E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace E_Commerce.OrderService.Application.Features.Orders.Command.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBus _eventBus;
        private readonly ILogger<CreateOrderCommandHandler> _logger;


        public CreateOrderCommandHandler(IOrderRepository orderRepository, IBus eventBus,
            ILogger<CreateOrderCommandHandler> logger)
        {
            _orderRepository = orderRepository;
            _eventBus = eventBus;
            _logger = logger;
        }

        public async Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Address address = new(request.Street, request.City, request.State, request.Country, request.ZipCode);
            Order dbOrder = new(request.UserName, request.Name, request.Email, address, request.Alias, request.CreditCard, request.CardTypeId, OrderStatus.Submitted, request.OrderAmount, request.WillPaymentRecord);
            request.OrderItems.ToList().ForEach(i => dbOrder.AddOrderItem(i.ProductId, i.ProductName, i.UnitPrice, i.PictureUrl, i.Quantity));
            await _orderRepository.AddAsync(dbOrder);
            await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            _logger.LogInformation("CreateOrderCommandHandler -> dbOrder saved");
            var orderStartedIntegrationEvent = new OrderStartedIntegrationEvent(request.CreditCard, dbOrder.OrderNumber, request.Name, request.Email, dbOrder.Id, dbOrder.OrderDate, dbOrder.OrderAmount);
            await _eventBus.Publish(orderStartedIntegrationEvent, cancellationToken);
            _logger.LogInformation("CreateOrderCommandHandler -> OrderStartedIntegrationEvent fired");
            return true;
        }
    }
}
