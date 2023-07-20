using E_Commerce.OrderService.Domain.Models;

namespace E_Commerce.OrderService.Application.IntegrationEvents.Events
{
    public class OrderCreatedIntegrationEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string UserName { get; }
        public string Name { get; }
        public string Email { get; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public CreditCard CreditCard { get; private set; }
        public int CardTypeId { get; private set; }
        public string? Alias { get; set; }
        public bool WillPaymentRecorded { get; private set; }
        public CustomerBasket? Basket { get; }

        public OrderCreatedIntegrationEvent(string userName, string name, string email,
            string city, string street, string state, string country, string zipCode,
           string? alias, CreditCard creditCard, bool willPaymentRecorded, CustomerBasket basket)
        {
            UserName = userName;
            Name = name;
            Email = email;
            City = city;
            Street = street;
            State = state;
            Country = country;
            ZipCode = zipCode;
            CreditCard = creditCard;
            Alias = alias;
            WillPaymentRecorded = willPaymentRecorded;
            Basket = basket;
        }
    }
}
