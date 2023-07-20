using E_Commerce.OrderService.Domain.Models;

namespace E_Commerce.OrderService.Application.IntegrationEvents.Events
{
    public class OrderStartedIntegrationEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public CreditCard CreditCard { get; set; }
        public string OrderNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid OrderId { get; set; }
        public DateTime OderDate { get; set; }
        public double Amount { get; set; }
        public OrderStartedIntegrationEvent(CreditCard creditCard, string orderNumber, string name, string email, Guid orderId, DateTime oderDate, double amount)
        {
            CreditCard = creditCard;
            OrderNumber = orderNumber;
            Name = name;
            Email = email;
            OrderId = orderId;
            OderDate = oderDate;
            Amount = amount;
        }
    }
}
