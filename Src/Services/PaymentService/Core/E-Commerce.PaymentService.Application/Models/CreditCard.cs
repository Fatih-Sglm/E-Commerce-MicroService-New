namespace E_Commerce.PaymentService.Application.Models
{
    public class CreditCard
    {
        public string CardNumber { get; private set; }
        public string CardHolderName { get; private set; }
        public string ExpirationYear { get; private set; }
        public string ExpirationMonth { get; private set; }
        public string CardSecurityNumber { get; private set; }

        public CreditCard(string cardNumber, string cardHolderName, string expirationYear, string expirationMonth, string cardSecurityNumber)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationYear = string.Concat("20", expirationYear);
            ExpirationMonth = expirationMonth;
            CardSecurityNumber = cardSecurityNumber;
        }
    }
}
