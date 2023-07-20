using E_Commerce.OrderService.Domain.SeedWork;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate
{
    public class OrderItem : BaseEntity, IValidatableObject
    {
        public uint ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }

        public decimal UnitPrice { get; set; }

        public uint Quantity { get; set; }

        public OrderItem(uint productId, string productName, decimal unitPrice, string pictureUrl, uint quantity = 1)
        {
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            PictureUrl = pictureUrl;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Quantity <= 0)
                results.Add(new ValidationResult("Invalid number of units", new[] { "Units" }));

            return results;
        }
    }
}
