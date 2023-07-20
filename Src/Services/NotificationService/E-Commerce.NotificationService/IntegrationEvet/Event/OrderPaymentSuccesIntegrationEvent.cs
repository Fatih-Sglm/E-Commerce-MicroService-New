namespace E_Commerce.NotificationService.IntegrationEvet.Event
{
    public class OrderPaymentSuccessIntegrationEvent
    {
        public int OrderId { get; set; }

        public OrderPaymentSuccessIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
