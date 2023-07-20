namespace E_Commerce.PaymentService.Application.Models
{
    public class PaymentModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Currency { get; private set; }
        public decimal Amount { get; private set; }
        public CreditCard CreditCard { get; private set; }

        public PaymentModel(string name, string email, string currency, decimal amount, CreditCard creditCard)
        {
            Name = name;
            Email = email;
            Currency = currency;
            Amount = amount;
            CreditCard = creditCard;
        }
    }
}
