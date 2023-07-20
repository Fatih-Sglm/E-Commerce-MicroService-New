using E_Commerce.PaymentService.Application.Models;

namespace E_Commerce.PaymentService.Application.IntegrationEvents.Events
{
    public class OrderStartedIntegrationEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public CreditCard CreditCard { get; set; }
        public string OrderNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }

        public OrderStartedIntegrationEvent(CreditCard creditCard, string orderNumber, string name, string email, Guid orderId, DateTime orderDate, decimal amount)
        {
            CreditCard = creditCard;
            OrderNumber = orderNumber;
            Name = name;
            Email = email;
            OrderId = orderId;
            OrderDate = orderDate;
            Amount = amount;
        }
    }
}
