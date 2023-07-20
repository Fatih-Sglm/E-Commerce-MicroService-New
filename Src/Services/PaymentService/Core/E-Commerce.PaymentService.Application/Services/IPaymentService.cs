using E_Commerce.PaymentService.Application.Models;

namespace E_Commerce.PaymentService.Application.Services
{
    public interface IPaymentService
    {
        Task<ResponseModel> Payment(PaymentModel paymentModel, CancellationToken ct);
    }
}
