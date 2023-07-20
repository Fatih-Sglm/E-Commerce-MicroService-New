using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Domain.AggregateModels.BuyerAggregate;
using E_Commerce.OrderService.Domain.Events;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.OrderService.Application.DomainEventHandlers
{
    class OrderStartedDomainEventHandler : INotificationHandler<OrderStartedDomainEvent>
    {
        private readonly IBuyerRepository _buyerRepository;

        public OrderStartedDomainEventHandler(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task Handle(OrderStartedDomainEvent orderStartedEvent, CancellationToken cancellationToken)
        {
            var cardTypeId = (orderStartedEvent.CardTypeId != 0) ? orderStartedEvent.CardTypeId : 1;

            Buyer? buyer = await _buyerRepository.GetAsync(i => i.UserName == orderStartedEvent.UserName, i => i.Include(i => i.PaymentMethods), cancellationToken: cancellationToken);

            buyer ??= new Buyer(orderStartedEvent.UserName, orderStartedEvent.FullName, orderStartedEvent.Email);

            await buyer.VerifyOrAddPaymentMethod(orderStartedEvent.Alias!,
                                           orderStartedEvent.CreditCard.CardNumber,
                                           orderStartedEvent.CreditCard.CardHolderName,
                                           orderStartedEvent.CreditCard.ExpirationMonth,
                                           orderStartedEvent.CreditCard.ExpirationYear,
                                           orderStartedEvent.CreditCard.CardSecurityNumber,
                                           cardTypeId,
                                           orderStartedEvent.Order.Id,
                                           orderStartedEvent.WillPaymentRecord);

            _ = buyer is not null ? _buyerRepository.Update(buyer) : await _buyerRepository.AddAsync(buyer!);

            await _buyerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
