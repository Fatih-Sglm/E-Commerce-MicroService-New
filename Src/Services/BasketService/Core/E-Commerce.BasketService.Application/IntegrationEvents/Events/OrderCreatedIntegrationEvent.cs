using E_Commerce.BasketService.Domain.Models;

namespace E_Commerce.BasketService.Application.IntegrationEvents.Events
{
    public class OrderCreatedIntegrationEvent
    {
        public string UserName { get; }
        public string Name { get; }
        public string Email { get; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public string? Alias { get; set; }
        public CreditCard CreditCard { get; private set; }
        public int CardTypeId { get; private set; }
        public bool WillPaymentRecorded { get; private set; }
        public CustomerBasket Basket { get; }
        public OrderCreatedIntegrationEvent(string userName, string name, string email, string city, string street,
            string state, string country, string zipCode, string? alias, string cardNumber, string cardHolderName,
            string expirationMonth, string expirationYear, string cardSecurityNumber, int cardTypeId,
            CustomerBasket basket, bool willPaymentRecorded = false)
        {
            UserName = userName;
            Name = name;
            Email = email;
            City = city;
            Alias = alias;
            WillPaymentRecorded = willPaymentRecorded;
            CreditCard = new(cardHolderName, cardNumber, expirationMonth, expirationYear, cardSecurityNumber);
            Street = street;
            State = state;
            Country = country;
            ZipCode = zipCode;
            CardTypeId = cardTypeId;
            Basket = basket;
        }

    }
}
