using System.ComponentModel.DataAnnotations;

namespace E_Commerce.BasketService.Domain.Models
{
    public class BasketItem : IValidatableObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ProductId { get; set; }

        public required string ProductName { get; set; }

        public double UnitPrice { get; set; }

        public double OldUnitPrice { get; set; }

        public int Quantity { get; set; }

        public required string PictureUrl { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Quantity < 1)
            {
                results.Add(new ValidationResult("Invalid number of units", new[] { "Quantity" }));
            }

            return results;
        }
    }
}
