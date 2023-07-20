namespace E_Commerce.BasketService.Domain.Models
{
    public class BasketCheckout
    {
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string State { get; set; }
        public required string Country { get; set; }
        public required string ZipCode { get; set; }
        public required string CardNumber { get; set; }
        public required string CardHolderName { get; set; }
        public required string ExpirationYear { get; set; }
        public required string ExpirationMonth { get; set; }
        public required string CardSecurityNumber { get; set; }
        public int CardTypeId { get; set; }
        public bool WillPaymentRecorded { get; set; }
        public string? Alias { get; set; } = null;
    }
}
