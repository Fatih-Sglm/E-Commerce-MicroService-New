namespace E_Commerce.OrderService.Application.Features.Orders.Models
{
    public class OrderDetailModel
    {
        public required string OrderNumber { get; init; }
        public required string OrderDate { get; init; }
        public required string Status { get; init; }
        public required string Description { get; init; }
        public required string Street { get; init; }
        public required string City { get; init; }
        public required string ZipCode { get; init; }
        public required string Country { get; init; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
        public decimal OrderAmount { get; set; }
    }
}
