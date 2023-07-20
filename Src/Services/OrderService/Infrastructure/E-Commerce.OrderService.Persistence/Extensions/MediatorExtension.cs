using E_Commerce.OrderService.Domain.SeedWork;
using E_Commerce.OrderService.Persistence.Contexts;
using MediatR;

namespace E_Commerce.OrderService.Persistence.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventAsync(this IMediator mediator, OrderDbContext orderContext)
        {
            var domainEntities = orderContext.ChangeTracker
                                   .Entries<BaseEntity>()
                                   .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents!)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
