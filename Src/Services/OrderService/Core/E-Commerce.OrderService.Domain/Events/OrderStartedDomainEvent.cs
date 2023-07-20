using E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate;
using E_Commerce.OrderService.Domain.Models;
using MediatR;

namespace E_Commerce.OrderService.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
        public string UserName { get; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int CardTypeId { get; }
        public string? Alias { get; }
        public CreditCard CreditCard { get; }

        public bool WillPaymentRecord { get; }
        public Order Order { get; }


        public OrderStartedDomainEvent(Order order, string userName, string fullName, string email,
                                       int cardTypeId, string? alias, CreditCard creditCard, bool willPaymentRecord)
        {
            Order = order;
            UserName = userName;
            FullName = fullName;
            Email = email;
            CardTypeId = cardTypeId;
            Alias = alias;
            CreditCard = creditCard;
            WillPaymentRecord = willPaymentRecord;
        }
    }
}
