namespace E_Commerce.OrderService.Application.Abstractions.Services
{
    public interface IBuyerService
    {
        Task<Guid> FindBuyerIdWithUserName(string userName);
    }
}
