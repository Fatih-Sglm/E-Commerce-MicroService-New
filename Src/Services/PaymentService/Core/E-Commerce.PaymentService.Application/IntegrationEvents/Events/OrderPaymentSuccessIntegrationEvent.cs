namespace E_Commerce.PaymentService.Application.IntegrationEvents.Events
{
    public class OrderPaymentSuccessIntegrationEvent
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string OrderNumber { get; private set; }
        public DateTime OrderDate { get; private set; }

        public OrderPaymentSuccessIntegrationEvent(Guid orderId, string name, string email, string orderNumber, DateTime orderDate)
        {
            OrderId = orderId;
            Name = name;
            Email = email;
            OrderNumber = orderNumber;
            OrderDate = orderDate;
        }
    }
}
