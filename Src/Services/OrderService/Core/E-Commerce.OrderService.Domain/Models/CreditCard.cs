namespace E_Commerce.OrderService.Domain.Models
{
    public class CreditCard
    {
        public string CardNumber { get; private set; }
        public string CardHolderName { get; private set; }
        public string ExpirationYear { get; private set; }
        public string ExpirationMonth { get; private set; }
        public string CardSecurityNumber { get; set; }

        public CreditCard(string cardHolderName, string cardNumber, string expirationMonth, string expirationYear, string cardSecurityNumber)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationYear = expirationYear;
            ExpirationMonth = expirationMonth;
            CardSecurityNumber = cardSecurityNumber;
        }
    }
}
