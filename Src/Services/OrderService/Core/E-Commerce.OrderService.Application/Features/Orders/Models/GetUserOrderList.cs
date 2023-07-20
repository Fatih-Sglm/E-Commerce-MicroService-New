namespace E_Commerce.OrderService.Application.Features.Orders.Models
{
    public class GetUserOrderList
    {
        public Guid Id { get; init; }
        public required string OrderDate { get; init; }
        public required string OrderStatus { get; init; }
        public required string? PaymentMethod { get; init; }
        public decimal OrderAmount { get; init; }
        public List<OrderItemDto> OrderItems { get; init; } = new List<OrderItemDto>();
    }
}
