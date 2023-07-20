using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Domain.AggregateModels.BuyerAggregate;
using E_Commerce.OrderService.Persistence.Concrete.Repository.GenericRepo;
using E_Commerce.OrderService.Persistence.Contexts;

namespace E_Commerce.OrderService.Persistence.Concrete.Repository
{
    public class BuyerRepository : GenericRepoitory<Buyer>, IBuyerRepository
    {
        public BuyerRepository(OrderDbContext context) : base(context)
        {
        }
    }
}
