using E_Commerce.OrderService.Domain.AggregateModels.BuyerAggregate;
using E_Commerce.OrderService.Domain.AggregateModels.OrderAggregate;
using E_Commerce.OrderService.Domain.SeedWork;
using E_Commerce.OrderService.Persistence.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace E_Commerce.OrderService.Persistence.Contexts
{
    public class OrderDbContext : DbContext, IUnitOfWork
    {

        public const string DEFAULT_SCHEMA = "ordering";
        private readonly IMediator _mediator;

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }


        public OrderDbContext(DbContextOptions<OrderDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is not BaseEntity entity) continue;
                var now = DateTime.Now;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreateDate = now;
                        break;

                    case EntityState.Modified:
                        entity.UpdateDate = now;
                        break;
                }
            }

            await _mediator.DispatchDomainEventAsync(this);
            return await SaveChangesAsync(cancellationToken) > 1;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
