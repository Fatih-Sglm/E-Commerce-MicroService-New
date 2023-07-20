namespace E_Commerce.PaymentService.Application.Enums
{
    public enum OrderStatus
    {
        Submitted,
        AwaitingPayment,
        AwaitingValidation,
        StockConfirmed,
        Paid,
        Shipped,
        Cancelled
    }
}
