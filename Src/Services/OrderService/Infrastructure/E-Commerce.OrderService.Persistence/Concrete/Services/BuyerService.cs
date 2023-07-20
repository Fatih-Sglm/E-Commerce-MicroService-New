using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Application.Abstractions.Services;
using E_Commerce.OrderService.Domain.AggregateModels.BuyerAggregate;

namespace E_Commerce.OrderService.Persistence.Concrete.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyerRepository;

        public BuyerService(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<Guid> FindBuyerIdWithUserName(string userName)
        {
            Buyer? buyer = await _buyerRepository.GetAsync(x => x.UserName == userName);
            ArgumentException.ThrowIfNullOrEmpty(nameof(buyer));
            return buyer!.Id;
        }
    }
}
