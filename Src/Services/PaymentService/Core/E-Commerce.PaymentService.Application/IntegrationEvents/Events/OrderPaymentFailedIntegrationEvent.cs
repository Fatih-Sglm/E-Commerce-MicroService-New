namespace E_Commerce.PaymentService.Application.IntegrationEvents.Events
{
    public class OrderPaymentFailedIntegrationEvent
    {
        public Guid OrderId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string OrderNumber { get; private set; }
        public string ErrorMessage { get; private set; }
        public DateTime OrderDate { get; private set; }

        public OrderPaymentFailedIntegrationEvent(Guid orderId, string name, string email, string orderNumber, string errorMessage, DateTime orderDate)
        {
            OrderId = orderId;
            Name = name;
            Email = email;
            OrderNumber = orderNumber;
            ErrorMessage = errorMessage;
            OrderDate = orderDate;
        }
    }
}
