using E_Commerce.OrderService.Application.Abstractions.Repostories;
using E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate;
using E_Commerce.OrderService.Persistence.Concrete.Repository.GenericRepo;
using E_Commerce.OrderService.Persistence.Contexts;

namespace E_Commerce.OrderService.Persistence.Concrete.Repository
{
    public class OrderRepository : GenericRepoitory<Order>, IOrderRepository
    {
        private readonly OrderDbContext _orderContext;
        public OrderRepository(OrderDbContext context) : base(context)
        {
            _orderContext = context;
        }

        public async Task<Order?> GetById(Guid id)
        {
            var entity = await GetAsync(x => x.Id == id);
            return entity ??= _orderContext.Orders.Local.FirstOrDefault(i => i.Id == id);

        }
    }
}
