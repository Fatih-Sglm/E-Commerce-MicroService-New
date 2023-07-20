namespace E_Commerce.NotificationService.IntegrationEvet.Event
{
    public class OrderPaymentFailedIntegrationEvent
    {
        public int OrderId { get; set; }

        public string ErrorMessage { get; set; }

        public OrderPaymentFailedIntegrationEvent(int orderId, string errorMessage)
        {
            OrderId = orderId;
            ErrorMessage = errorMessage;
        }
    }
}
