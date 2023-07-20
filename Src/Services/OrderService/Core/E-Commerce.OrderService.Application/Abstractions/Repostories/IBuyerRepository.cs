using E_Commerce.OrderService.Application.Abstractions.Repostories.GenericRepo;
using E_Commerce.OrderService.Domain.AggregateModels.BuyerAggregate;

namespace E_Commerce.OrderService.Application.Abstractions.Repostories
{
    public interface IBuyerRepository : IGenericRepository<Buyer>
    {
    }
}
