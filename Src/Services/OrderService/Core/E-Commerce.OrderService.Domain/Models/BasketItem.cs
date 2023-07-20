namespace E_Commerce.OrderService.Domain.Models
{
    public class BasketItem
    {
        public required string Id { get; set; }

        public uint ProductId { get; set; }

        public required string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal OldUnitPrice { get; set; }

        public uint Quantity { get; set; }

        public required string PictureUrl { get; set; }
    }
}
