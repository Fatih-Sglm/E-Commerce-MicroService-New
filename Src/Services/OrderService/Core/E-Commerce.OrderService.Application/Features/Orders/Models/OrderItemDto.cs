namespace E_Commerce.OrderService.Application.Features.Orders.Models
{
    public class OrderItemDto
    {
        public uint ProductId { get; set; }
        public required string ProductName { get; init; }

        public decimal UnitPrice { get; init; }

        public uint Quantity { get; init; }

        public required string PictureUrl { get; init; }
    }
}
