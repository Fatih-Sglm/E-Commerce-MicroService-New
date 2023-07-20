using E_Commerce.PaymentService.Application.Models;
using E_Commerce.PaymentService.Application.Services;
using Stripe;

namespace E_Commerce.PaymentService.Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly ChargeService _chargeService;
        private readonly CustomerService _customerService;
        private readonly TokenService _tokenService;

        public PaymentService(ChargeService chargeService, CustomerService customerService, TokenService tokenService)
        {
            _chargeService = chargeService;
            _customerService = customerService;
            _tokenService = tokenService;
        }

        public async Task<ResponseModel> Payment(PaymentModel paymentModel, CancellationToken ct)
        {
            TokenCreateOptions tokenOptions = new()
            {
                Card = new TokenCardOptions
                {
                    Name = paymentModel.Name,
                    Number = paymentModel.CreditCard.CardNumber,
                    ExpYear = paymentModel.CreditCard.ExpirationYear,
                    ExpMonth = paymentModel.CreditCard.ExpirationMonth,
                    Cvc = paymentModel.CreditCard.CardSecurityNumber
                }
            };

            Token stripeToken = await _tokenService.CreateAsync(tokenOptions, null, ct);

            CustomerCreateOptions customerOptions = new()
            {
                Name = paymentModel.Name,
                Email = paymentModel.Email,
                Source = stripeToken.Id
            };

            Customer createdCustomer = await _customerService.CreateAsync(customerOptions, null, ct);


            ChargeCreateOptions paymentOptions = new()
            {
                Customer = createdCustomer.Id,
                ReceiptEmail = createdCustomer.Email,
                Currency = paymentModel.Currency,
                Amount = ((long?)paymentModel.Amount) * 100
            };

            var createdPayment = await _chargeService.CreateAsync(paymentOptions, null, ct);

            return new()
            {
                Currency = createdPayment.Currency,
                ErrorMessage = createdPayment.FailureMessage,
                IsPaid = createdPayment.Paid,
                TotalAmount = createdPayment.Amount,
                ReceiptNumber = createdPayment.ReceiptNumber,
                ReceiptUrl = createdPayment.ReceiptUrl,
                Invoice = createdPayment.Invoice,
            };
        }
    }
}
