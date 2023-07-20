using E_Commerce.OrderService.Domain.Exceptions;
using E_Commerce.OrderService.Domain.SeedWork;

namespace E_Commerce.OrderService.Domain.AggregateModels.BuyerAggregate
{
    public class PaymentMethod : BaseEntity
    {
        public string? Alias { get; set; }
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string CardHolderName { get; set; }
        public string ExpirationYear { get; private set; }
        public string ExpirationMonth { get; private set; }
        public CardType CardType { get; private set; }
        public PaymentMethod(string alias, string cardNumber, string cardHolderName,
             string expirationMonth, string expirationYear, string securityNumber, int cardTypeId)
        {

            CardNumber = !string.IsNullOrWhiteSpace(cardNumber) ? cardNumber : throw new OrderingDomainException(nameof(cardNumber));
            SecurityNumber = !string.IsNullOrWhiteSpace(securityNumber) ? securityNumber : throw new OrderingDomainException(nameof(securityNumber));
            CardHolderName = !string.IsNullOrWhiteSpace(cardHolderName) ? cardHolderName : throw new OrderingDomainException(nameof(cardHolderName));
            Alias = alias;
            ExpirationYear = expirationYear;
            ExpirationMonth = expirationMonth;
            CardType = Enumeration.FromValue<CardType>(cardTypeId);
        }

        public bool IsEqualTo(string cardNumber, string cardHolderName,
             string expirationMonth, string expirationYear, string securityNumber, int cardTypeId)
        {

            bool value = CardType == Enumeration.FromValue<CardType>(cardTypeId)
                && CardNumber == cardNumber
                && CardHolderName == cardHolderName
                && ExpirationMonth == expirationMonth
                && ExpirationYear == expirationYear
                && SecurityNumber == securityNumber;

            return value;
        }
    }
}
