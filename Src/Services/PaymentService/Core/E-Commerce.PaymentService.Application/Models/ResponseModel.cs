using Stripe;

namespace E_Commerce.PaymentService.Application.Models
{
    public class ResponseModel
    {
        public required bool IsPaid { get; set; }
        public required string? ErrorMessage { get; set; }
        public required long TotalAmount { get; set; }
        public required string Currency { get; set; }
        public required string ReceiptNumber { get; set; }
        public required string ReceiptUrl { get; set; }
        public required Invoice Invoice { get; set; }
    }
}
