namespace E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate
{
    internal static class OrderStatusHelpers
    {
        public static OrderStatus Submitted = new(1, nameof(Submitted).ToLowerInvariant());
    }
}